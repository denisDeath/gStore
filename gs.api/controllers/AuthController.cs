using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using gs.api.contracts.reseller.dto.auth;
using gs.api.contracts.reseller.services.interfaces;
using JetBrains.Annotations;

namespace gs.api.controllers
{
    [Route("api/auth/[action]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController([NotNull] IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        [HttpPost]
        public async Task Token([FromBody] GetAccessTokenRequest request)
        {
            try
            {
                GetAccessTokenResponse response = _authService.GetAccessToken(request);
                // сериализация ответа
                Response.ContentType = "application/json";
                await Response.WriteAsync(JsonConvert.SerializeObject(response, 
                    new JsonSerializerSettings { Formatting = Formatting.Indented }));
            }
            catch (Exception)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username or password.");
            }
        }
    }
}