using System;
using gs.api.auth;
using gs.api.contracts.reseller.dto.registration;
using gs.api.contracts.reseller.services.interfaces;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gs.api.controllers
{
    [Route("api/resellers/registration/[action]")]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController([NotNull] IRegistrationService registrationService)
        {
            _registrationService = registrationService ?? throw new ArgumentNullException(nameof(registrationService));
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
            _registrationService.SaveOrganizationSettings(request);
        }

        [Authorize(Roles = Roles.ResellerAdmin)]
        [HttpPost]
        public void ChangePassword([FromBody] ChangePasswordRequest request)
        {
            _registrationService.ChangePassword(request);
        }

        [Authorize(Roles = Roles.ResellerAdmin)]
        [HttpPost]
        public void ChangePhoneNumber([FromBody] ChangePhoneNumberRequest request)
        {
             _registrationService.ChangePhoneNumber(request);
        }

        [HttpPost]
        public string Test()
        {
            return _registrationService.Test();
        }
    }
}