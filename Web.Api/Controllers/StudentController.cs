﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Api.Common;

namespace Web.Api.Controllers
{
    [RoutePrefix("Student")]
    public class StudentController : ApiController
    {
        ResponseHelper responseHealper = new ResponseHelper();

        [Route("GetUser")]
        [HttpGet]
        public IHttpActionResult GetUser()
        {
            return new GenericActionResultUsingType<UserInfo>(responseHealper.GetUser(), Request);
        }

        [Route("Updateuser")]
        [HttpPut, HttpOptions]
        public IHttpActionResult UpdatUser()
        {
            return new GenericActionResultUsingType<UserInfo>(responseHealper.UpdateUser(), Request);
        }
    }
}