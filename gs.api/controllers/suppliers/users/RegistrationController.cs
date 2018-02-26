using System;
using gs.api.contracts.reseller;
using gs.api.contracts.reseller.dto.registration;
using gs.api.contracts.reseller.services.interfaces;
using gs.api.contracts.suppliers;
using Microsoft.AspNetCore.Mvc;

namespace gs.api.controllers.suppliers.users
{
    [Route("api/suppliers/users/registration/[action]")]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService RegistrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            RegistrationService = registrationService;
        }

        [HttpPut]
        public RegisterOrganizationResponse RegisterOrganization([FromBody] RegisterOrganizationRequest request)
        {
            return RegistrationService.RegisterOrganization(request);
        }

        [HttpDelete]
        public void Delete()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public AuthResponse Auth([FromBody] AuthRequest request)
        {
            throw new NotImplementedException();
        }
    }
}