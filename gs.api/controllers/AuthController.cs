using System;
using Microsoft.AspNetCore.Mvc;
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
        public GetAccessTokenResponse Token([FromBody] GetAccessTokenRequest request)
        {
            return _authService.GetAccessToken(request);
        }
    }
}