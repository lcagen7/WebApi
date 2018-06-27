using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT
{
    public static class ClaimHelper
    {

        public static string GetTokenValue(string access_token, string type)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadToken(access_token) as JwtSecurityToken;

            if (token != null)
            {
                var claim = token.Claims.Single(c => c.Type == type);
                if (claim != null)
                {
                    return claim.Value;
                }
            }
            return null;
        }

    }
}
