using System;
using gs.api.contracts.reseller.auth;
using gs.api.contracts.reseller.dto.auth;
using gs.api.contracts.reseller.services.interfaces;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace gs.api.controllers.resellers
{
    [Route("api/resellers/auth/[action]")]
    public class AuthController : ControllerBase, IAuthService
    {
        private readonly IAuthService AuthService;

        public AuthController([NotNull] IAuthService authService)
        {
            AuthService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        [HttpPost]
        public GetAccessTokenResponse GetAccessToken([FromBody] GetAccessTokenRequest request)
        {
            return AuthService.GetAccessToken(request);
        }
    }
}