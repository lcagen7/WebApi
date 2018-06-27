using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http;
using System.Threading;
using System.Web.Http.Results;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Net.Http.Headers;

namespace JWT
{
    public class BearerAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        #region Properties

        public bool AllowMultiple
        {
            get
            {
                return false;
            }
        }

        #endregion Properties

        #region Methods

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            if (authorization == null || authorization.Scheme != "Bearer")
            {
                // Not a Bearer authorized request.
                // Just let it pass through without a Principal
                return;
            }

            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new UnauthorizedResult(null, request);
                return;
            }

            // Validate the JWT
            var token = authorization.Parameter;
            var validationParams = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = SecurityConfiguration.TokenIssuer,

                ValidateAudience = true,
                ValidAudience = SecurityConfiguration.TokenAudience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = SecurityConfiguration.SecurityKey,

                RequireExpirationTime = true,
                ValidateLifetime = true
            };

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.InboundClaimTypeMap["name"] = ClaimTypes.Name;

                SecurityToken securityToken;
                context.Principal = tokenHandler.ValidateToken(token, validationParams, out securityToken);
            }
            catch (Exception)
            {
                context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], request);
            }
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            // Challenge was added in at AuthenticateAsync
            return Task.FromResult(0);
        }

        #endregion Methods
    }
}
