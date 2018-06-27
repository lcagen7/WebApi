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
            if (loginId == "Admin" && password == "Admin")
            {
                UserInfo ui = new UserInfo();
                ui.FirstName = "Admin";
                ui.LastName = "User";
                ui.LoginId = "adminuser";
                ui.RoleId = 1;
                ui.UserId = 1;
                token=JWT.OAuthToken.Create(ui);
            }
            return token;
        }
    }
}
