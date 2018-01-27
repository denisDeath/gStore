using System;
using gs.api.contracts.suppliers;
using Microsoft.AspNetCore.Mvc;

namespace gs.api.controllers.suppliers.users
{
    [Route("api/suppliers/users/registration/[action]")]
    public class RegistrationController : Controller
    {
        [HttpPut]
        public void Register()
        {
            throw new NotImplementedException();
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