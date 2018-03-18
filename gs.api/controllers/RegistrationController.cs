using System;
using System.Linq;
using System.Security.Claims;
using gs.api.auth;
using gs.api.contracts.reseller;
using gs.api.contracts.reseller.dto.exceptions;
using gs.api.contracts.reseller.dto.registration;
using gs.api.contracts.reseller.services.interfaces;
using gs.api.infrastructure;
using gs.api.storage;
using gs.api.storage.model;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace gs.api.controllers.resellers
{
    [Route("api/resellers/registration/[action]")]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;
        private readonly CallContext _callContext;
        private readonly Context _context;

        public RegistrationController([NotNull] IRegistrationService registrationService, CallContext callContext,
            [NotNull] Context context)
        {
            _registrationService = registrationService ?? throw new ArgumentNullException(nameof(registrationService));
            _callContext = callContext;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpPost]
        public RegisterOrganizationResponse RegisterOrganization([FromBody] RegisterOrganizationRequest request)
        {
            return _registrationService.RegisterOrganization(request);
        }

        [HttpPost]
        public IsAccountExistsResponse IsAccountExists([FromBody] IsAccountExistsRequest request)
        {
            return _registrationService.IsAccountExists(request);
        }

        [Authorize(Roles = Roles.ResellerAdmin)]
        [HttpPost]
        public void SaveOrganizationSettings([FromBody] SaveOrganizationSettingsRequest request)
        {
            _registrationService.SaveOrganizationSettings(request, GetCurrentOrganization());
        }

        [Authorize(Roles = Roles.ResellerAdmin)]
        [HttpPost]
        public void ChangePassword([FromBody] ChangePasswordRequest request)
        {
            _registrationService.ChangePassword(request, GetCurrentOrganization());
        }

        [Authorize(Roles = Roles.ResellerAdmin)]
        [HttpPost]
        public void ChangePhoneNumber([FromBody] ChangePhoneNumberRequest request)
        {
             _registrationService.ChangePhoneNumber(request, GetCurrentOrganization());
        }

        [HttpPost]
        public string Test()
        {
            return _callContext.CorrelationId.ToString();
        }
        
        [NotNull]
        private IeOrganization GetCurrentOrganization()
        {
            Claim currentPhoneClaim =
                HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultNameClaimType);
            if (currentPhoneClaim == null)
                throw new UnauthorizedException();
            
            var user = _context.Users.FirstOrDefault(u => u.PhoneNumber == currentPhoneClaim.Value);
            if (user == null)
                throw new UnauthorizedException();

            var organization = _context.IeOrganizations.FirstOrDefault(o => o.Owner.UserId == user.UserId);
            if (organization == null)
                throw new InvalidOperationException($"User with id {user.UserId} not owns any organization.");
            return organization;
        }
    }
}