using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService
    {
        public UserInfo GetUser()
        {
            return new UserInfo()
            {
                FirstName = "FName1",
                LastName = "LName1",
                LoginId = "FL1",
                RoleId = 1,
                UserId = 1
            };
        }

        public UserInfo UpdateUser()
        {
            return new UserInfo()
            {
                FirstName = "FName1Updated",
                LastName = "LName1Updated",
                LoginId = "FL1",
                RoleId = 1,
                UserId = 1
            };
        }
    }
}
