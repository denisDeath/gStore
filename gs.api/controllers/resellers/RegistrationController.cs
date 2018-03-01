using System;
using gs.api.contracts.reseller;
using gs.api.contracts.reseller.dto.registration;
using gs.api.contracts.reseller.services.interfaces;
using gs.api.contracts.suppliers;
using Microsoft.AspNetCore.Mvc;

namespace gs.api.controllers.resellers
{
    [Route("api/resellers/registration/[action]")]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService RegistrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            RegistrationService = registrationService;
        }

        [HttpPost]
        public RegisterOrganizationResponse RegisterOrganization([FromBody] RegisterOrganizationRequest request)
        {
            return RegistrationService.RegisterOrganization(request);
        }

        [HttpPost]
        public IsOrganizationExistsResponse IsOrganizationExists([FromBody] IsOrganizationExistsRequest request)
        {
            return RegistrationService.IsOrganizationExists(request);
        }

        [HttpPost]
        public bool IsUserEmailExists([FromBody] IsUserEmailExistsRequest request)
        {
            return RegistrationService.IsUserEmailExists(request);
        }
        
        [HttpPost]
        public AuthResponse Auth([FromBody] AuthRequest request)
        {
            throw new NotImplementedException();
        }
    }
}