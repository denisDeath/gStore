using System;
using System.Linq;
using System.Text;
using gs.api.contracts.reseller;
using gs.api.contracts.reseller.dto.exceptions;
using gs.api.contracts.reseller.dto.registration;
using gs.api.contracts.reseller.services.interfaces;
using gs.api.converters.reseller;
using gs.api.storage;
using gs.api.storage.model;
using JetBrains.Annotations;

using OrganizationDb = gs.api.storage.model.Organization;
using UserDb = gs.api.storage.model.User;

namespace gs.api.services.reseller
{
    public class RegistrationService : IRegistrationService
    {
        private readonly Context Context;

        public RegistrationService([NotNull] Context context, [NotNull] IAuthService authService)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public RegisterOrganizationResponse RegisterOrganization([NotNull] RegisterOrganizationRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            // add user
            if (IsUserExistsByPhone(request.UserPhoneNumber))
                throw new UserAlreadyExistsException();
            UserDb user = request.ConvertToUser();
            Context.Add(user);
            
            // add organization
            var org = request.ConvertToOrganization();
            org.Owner = user;
            Context.Add(org);
            Context.SaveChanges();
            
            // generate and save token
            var newToken = AuthService.GenerateToken();
            user.Token = newToken.Token;
            user.TokenExpireDate = newToken.Expiration;
            Context.SaveChanges();
            return new RegisterOrganizationResponse(user.Token);
        }

        public IsAccountExistsResponse IsAccountExists([NotNull] IsAccountExistsRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            bool byPhone = IsUserExistsByPhone(request.UserPhoneNumber);
            return new IsAccountExistsResponse(byPhone);
        }

        public void SaveOrganizationSettings([NotNull] SaveOrganizationSettingsRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var organization = GetOrganization(request.Token);
            var user = organization.Owner;

            user.FirstName = request.OwnerFirstName ?? user.FirstName;
            user.LastName = request.OwnerLastName ?? user.LastName;
            user.Patronymic = request.OwnerPatronymic ?? user.Patronymic;

            organization.TradeMark = request.TradeMark ?? organization.TradeMark;
            organization.FullName = request.FullName ?? organization.FullName;
            organization.Address = request.Address ?? organization.Address;
            organization.Phone = request.Phone ?? organization.Phone;
            organization.Inn = request.Inn ?? organization.Inn;
            organization.UseVat = request.UseVat ?? organization.UseVat;

            Context.SaveChanges();
        }

        public void ChangePassword([NotNull] ChangePasswordRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var organization = GetOrganization(request.Token);
            organization.Owner.Password = request.NewPassword;
            Context.SaveChanges();
        }

        public void ChangePhoneNumber([NotNull] ChangePhoneNumberRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var organization = GetOrganization(request.Token);
            if (organization.Owner.PhoneNumber == request.NewPhoneNumber)
                return;

            if (IsUserExistsByPhone(request.NewPhoneNumber))
                throw new UserPhoneAlreadyInUseException();
            
            organization.Owner.PhoneNumber = request.NewPhoneNumber;
            Context.SaveChanges();
        }

        private bool IsUserExistsByPhone(string userPhone)
        {
            return Context.Users.Any(u => u.PhoneNumber == userPhone);
        }
        
        [NotNull]
        private IeOrganization GetOrganization(string token)
        {
            var user = Context.Users.FirstOrDefault(u => u.Token == token);
            if (user == null)
                throw new UnauthorizedException();

            var organization = Context.IeOrganizations.FirstOrDefault(o => o.Owner.UserId == user.UserId);
            if (organization == null)
                throw new InvalidOperationException($"User with id {user.UserId} not owns any organization.");
            return organization;
        }
    }
}