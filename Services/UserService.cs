using Model;
using System;
using System.Collections.Generic;

namespace Services
{
    public class UserService
    {
        public UserInfo GetUserWithParam(string loginId)
        {
            if (loginId.ToLower().Equals("admin"))
            {
                return new UserInfo()
                {
                    FirstName = "Admin" + " " + Guid.NewGuid().ToString().Substring(8, 6),
                    LastName = "User" + " " + Guid.NewGuid().ToString().Substring(8, 6),
                    LoginId = "admin",
                    RoleId = 1,
                    UserId = 1
                };
            }
            else
            {
                return new UserInfo()
                {
                    FirstName = "Normal" + " " + Guid.NewGuid().ToString().Substring(8, 6),
                    LastName = "User" + " " + Guid.NewGuid().ToString().Substring(8, 6),
                    LoginId = "user",
                    RoleId = 2,
                    UserId = 2
                };
            }
        }

        public UserInfo GetUser()
        {
            return new UserInfo()
            {
                FirstName = "Demo" + " " + Guid.NewGuid().ToString().Substring(8, 6),
                LastName = "User" + " " + Guid.NewGuid().ToString().Substring(8, 6),
                LoginId = "demo",
                RoleId = 1,
                UserId = 1
            };
        }

        public IList<UserInfo> GetAllUsers()
        {
            List<UserInfo> users = new List<UserInfo>()
            {
                new UserInfo()
                {
                    FirstName = "FName1",
                    LastName = "LName1",
                    LoginId = "FL1",
                    RoleId = 1,
                    UserId = 1
                },
                new UserInfo()
                {
                    FirstName = "FName2",
                    LastName = "LName2",
                    LoginId = "FL2",
                    RoleId = 2,
                    UserId = 2
                },
                new UserInfo()
                {
                    FirstName = "FName3",
                    LastName = "LName3",
                    LoginId = "FL3",
                    RoleId = 3,
                    UserId = 3
                },
                new UserInfo()
                {
                    FirstName = "FName4",
                    LastName = "LName4",
                    LoginId = "FL4",
                    RoleId = 4,
                    UserId = 4
                },
                new UserInfo()
                {
                    FirstName = "FName5",
                    LastName = "LName5",
                    LoginId = "FL5",
                    RoleId = 5,
                    UserId = 5
                }
            };

            return users;
        }

        public UserInfo UpdateUser(UserInfo userInfo)
        {
            return new UserInfo()
            {
                FirstName = userInfo.FirstName + " " + Guid.NewGuid().ToString().Substring(8, 6),
                LastName = userInfo.LastName + " " + Guid.NewGuid().ToString().Substring(8, 6),
                LoginId = userInfo.LoginId,
                RoleId = userInfo.RoleId,
                UserId = userInfo.UserId
            };
        }
    }
}
