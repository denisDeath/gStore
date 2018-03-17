using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using gs.api.auth;
using gs.api.contracts.reseller.dto.auth;
using gs.api.contracts.reseller.dto.exceptions;
using gs.api.contracts.reseller.services.interfaces;
using gs.api.storage;
using gs.api.storage.model;
using JetBrains.Annotations;
using Microsoft.IdentityModel.Tokens;

namespace gs.api.services.reseller
{
    public class AuthService : IAuthService
    {
        private readonly Context Context;
        private const uint TokenExpirationInMinutes = 10;

        public AuthService([NotNull] Context context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public GetAccessTokenResponse GetAccessToken(GetAccessTokenRequest request)
        {
            return GetAccessToken(request.PhoneNumber, request.Password);
        }

        internal GetAccessTokenResponse GetAccessToken(string phoneNumber, string password)
        {
            ClaimsIdentity identity = GetIdentity(phoneNumber, password);
            if (identity == null)
                throw new IncorrectAccessTokenRequestException();

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new GetAccessTokenResponse(identity.Name, encodedJwt);
        }

        private ClaimsIdentity GetIdentity(string phoneNumber, string password)
        {
            User user = Context.Users.FirstOrDefault(x => x.PhoneNumber == phoneNumber && x.Password == password);
            if (user == null) return null;
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.PhoneNumber),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, Roles.ResellerAdmin)
            };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
        
        public static (string Token, DateTime Expiration) GenerateToken()
        {
            byte[] bytes = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
            string token = Convert.ToBase64String(bytes);
            DateTime expiration = DateTime.UtcNow.AddMinutes(TokenExpirationInMinutes);
            
            return (token, expiration);
        }
    }
}