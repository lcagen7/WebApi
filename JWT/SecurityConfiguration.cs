using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT
{
    public static class SecurityConfiguration
    {
        public static readonly string SigningKey = "1f2603f3-0753-4fb0-a136-6d1f7635ea67";
        public static readonly string TokenIssuer = "rbagri";
        public static readonly string TokenAudience = "Web.Api";
        public static readonly int lifetimeInMinutes = 60;
        public static readonly SecurityKey SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SigningKey));
        public static readonly SigningCredentials SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
    }
}
