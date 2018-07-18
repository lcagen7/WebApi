using Model;
using Services;
using System;

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
        public UserInfo UpdateUser()
        {
            UserService us = new UserService();
            return us.UpdateUser();
        }
    }
}