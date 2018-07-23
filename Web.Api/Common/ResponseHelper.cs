using Model;
using Services;
using System;
using System.Collections.Generic;

namespace Web.Api.Common
{
    public class ResponseHelper
    {
        public UserInfo GetUser()
        {
            UserService us = new UserService();
            return us.GetUser();
        }

        public Func<UserInfo> GetUserInfoFunction()
        {
            UserService us = new UserService();
            return us.GetUser;
        }

        public IList<UserInfo> GetAllUsers()
        {
            UserService us = new UserService();
            return us.GetAllUsers();
        }

        public UserInfo UpdateUser(UserInfo userInfo)
        {
            UserService us = new UserService();
            return us.UpdateUser(userInfo);
        }
    }
}