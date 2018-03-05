using System;
using System.Linq;
using System.Text;
using gs.api.contracts.reseller;
using gs.api.contracts.reseller.dto.exceptions;
using gs.api.contracts.reseller.dto.registration;
using gs.api.contracts.reseller.services.interfaces;
using gs.api.converters.reseller;
using gs.api.storage;
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
        
        private bool IsUserExistsByPhone(string userPhone)
        {
            return Context.Users.Any(u => u.PhoneNumber == userPhone);
        }
    }
}