using Microsoft.IdentityModel.Tokens;
using Model;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JWT
{
    public class OAuthToken
    {
        protected OAuthToken()
        {
        }
        public static string Create(UserInfo userInfo)
        {
            // Create the JWT
            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userInfo.UserId.ToString()),
                new Claim(ClaimTypes.Role, userInfo.RoleId.ToString()),
                new Claim("FirstName", userInfo.FirstName),
                new Claim("LastName", userInfo.LastName),
                new Claim("UserID", userInfo.UserId.ToString()),
                new Claim("SessionID", Guid.NewGuid().ToString())
            });

            var now = DateTime.UtcNow;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Issuer = SecurityConfiguration.TokenIssuer,
                Audience = SecurityConfiguration.TokenAudience,
                SigningCredentials = SecurityConfiguration.SigningCredentials,
                IssuedAt = now,
                Expires = now.AddMinutes(SecurityConfiguration.lifetimeInMinutes)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        /// <summary>
        /// Validate token with session id.
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        public static bool IsValideSessionId(string access_token, string sessionID)
        {
            try
            {
                var token_SessionID = ClaimHelper.GetTokenValue(access_token, "SessionID");
                return token_SessionID == sessionID;
            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}
