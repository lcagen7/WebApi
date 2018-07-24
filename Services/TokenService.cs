using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TokenService
    {
        public string GetToken(string loginId, string password)
        {
            string token = String.Empty;
            if (loginId.ToLower() == "admin" && password == "password")
            {
                UserInfo ui = new UserService().GetUser();
                token=JWT.OAuthToken.Create(ui);
            }
            return token;
        }
    }
}
