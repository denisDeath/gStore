using System;
using System.Linq;
using System.Text;
using gs.api.contracts.reseller;
using gs.api.contracts.reseller.dto.auth;
using gs.api.contracts.reseller.dto.exceptions;
using gs.api.contracts.reseller.dto.registration;
using gs.api.contracts.reseller.services.interfaces;
using gs.api.converters.reseller;
using gs.api.storage;
using gs.api.storage.model;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using OrganizationDb = gs.api.storage.model.Organization;
using UserDb = gs.api.storage.model.User;

namespace gs.api.services.reseller
{
    public class RegistrationService : IRegistrationService
    {
        private readonly Context _context;
        private readonly IAuthService _authService;

        public RegistrationService([NotNull] Context context, [NotNull] IAuthService authService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        public RegisterOrganizationResponse RegisterOrganization([NotNull] RegisterOrganizationRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            // add user
            if (IsUserExistsByPhone(request.UserPhoneNumber))
                throw new UserAlreadyExistsException();
            UserDb user = request.ConvertToUser();
            _context.Add(user);
            
            // add organization
            var org = request.ConvertToOrganization();
            org.Owner = user;
            _context.Add(org);
            _context.SaveChanges();
            
            // authenticate new user
            var authRequest = new GetAccessTokenRequest(user.PhoneNumber, user.Password);
            var authResult = _authService.GetAccessToken(authRequest);
            return new RegisterOrganizationResponse(authResult.PhoneNumber, authResult.Token);
        }

        public IsAccountExistsResponse IsAccountExists([NotNull] IsAccountExistsRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            bool byPhone = IsUserExistsByPhone(request.UserPhoneNumber);
            return new IsAccountExistsResponse(byPhone);
        }

        public void SaveOrganizationSettings([NotNull] SaveOrganizationSettingsRequest request,
            [NotNull] IeOrganization organization)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (organization == null) throw new ArgumentNullException(nameof(organization));
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

            _context.SaveChanges();
        }

        public void ChangePassword([NotNull] ChangePasswordRequest request, [NotNull] IeOrganization organization)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            organization.Owner.Password = request.NewPassword;
            _context.SaveChanges();
        }

        public void ChangePhoneNumber([NotNull] ChangePhoneNumberRequest request, [NotNull] IeOrganization organization)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            if (organization.Owner.PhoneNumber == request.NewPhoneNumber)
                return;

            if (IsUserExistsByPhone(request.NewPhoneNumber))
                throw new UserPhoneAlreadyInUseException();
            
            organization.Owner.PhoneNumber = request.NewPhoneNumber;
            _context.SaveChanges();
        }

        private bool IsUserExistsByPhone(string userPhone)
        {
            return _context.Users.Any(u => u.PhoneNumber == userPhone);
        }
    }
}