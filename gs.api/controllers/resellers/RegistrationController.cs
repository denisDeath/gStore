using gs.api.contracts.reseller;
using gs.api.contracts.reseller.dto.registration;
using gs.api.contracts.reseller.services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gs.api.controllers.resellers
{
    [Route("api/resellers/registration/[action]")]
    public class RegistrationController : Controller, IRegistrationService
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
        public IsAccountExistsResponse IsAccountExists([FromBody] IsAccountExistsRequest request)
        {
            return RegistrationService.IsAccountExists(request);
        }
    }
}