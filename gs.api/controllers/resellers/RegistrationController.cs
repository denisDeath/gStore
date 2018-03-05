using System;
using gs.api.contracts.reseller;
using gs.api.contracts.reseller.dto.registration;
using gs.api.contracts.reseller.services.interfaces;
using gs.api.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace gs.api.controllers.resellers
{
    [Route("api/resellers/registration/[action]")]
    public class RegistrationController : Controller, IRegistrationService
    {
        private readonly IRegistrationService _registrationService;
        private readonly CallContext _callContext;

        public RegistrationController(IRegistrationService registrationService, CallContext callContext)
        {
            _registrationService = registrationService;
            _callContext = callContext;
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

        [HttpPost]
        public void SaveOrganizationSettings([FromBody] SaveOrganizationSettingsRequest request)
        {
            _registrationService.SaveOrganizationSettings(request);
        }

        [HttpPost]
        public void ChangePassword([FromBody] ChangePasswordRequest request)
        {
            _registrationService.ChangePassword(request);
        }

        [HttpPost]
        public void ChangePhoneNumber([FromBody] ChangePhoneNumberRequest request)
        {
             _registrationService.ChangePhoneNumber(request);
        }

        [HttpPost]
        public string Test()
        {
            return _callContext.CorrelationId.ToString();
        }
    }
}