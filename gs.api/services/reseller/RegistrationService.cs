using System;
using System.Linq;
using gs.api.contracts.reseller.dto.auth;
using gs.api.contracts.reseller.dto.exceptions;
using gs.api.contracts.reseller.dto.registration;
using gs.api.contracts.reseller.services.interfaces;
using gs.api.converters.reseller;
using gs.api.infrastructure;
using gs.api.storage;
using JetBrains.Annotations;
using OrganizationDb = gs.api.storage.model.Organization;
using UserDb = gs.api.storage.model.User;

namespace gs.api.services.reseller
{
    public class RegistrationService : IRegistrationService
    {
        private readonly Context _context;
        private readonly IAuthService _authService;
        private readonly CallContext _callContext;

        public RegistrationService([NotNull] Context context, [NotNull] IAuthService authService, 
            [NotNull] CallContext callContext)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _callContext = callContext ?? throw new ArgumentNullException(nameof(callContext));
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

        public GetOrganizationSettingsResponse GetOrganizationSettings()
        {
            var organization = _callContext.OrganizationAndUser.Value.Organization;
            var user = organization.Owner;

            var settings = CommonMapper.ConvertToOrganizationSettings(organization, user);
            return new GetOrganizationSettingsResponse(settings);
        }

        public void SaveOrganizationSettings([NotNull] SaveOrganizationSettingsRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var organization = _callContext.OrganizationAndUser.Value.Organization;
            var user = organization.Owner;

            var db = CommonMapper.ConvertToContracts(request.Settings);
            user.UpdateFieldsWithoutPasswordAndPhone(db.User);
            organization.UpdateFields(db.Organization);

            _context.SaveChanges();
        }

        public void ChangePassword([NotNull] ChangePasswordRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var organization = _callContext.OrganizationAndUser.Value.Organization;
            organization.Owner.Password = request.NewPassword;
            _context.SaveChanges();
        }

        public void ChangePhoneNumber([NotNull] ChangePhoneNumberRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var organization = _callContext.OrganizationAndUser.Value.Organization;
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