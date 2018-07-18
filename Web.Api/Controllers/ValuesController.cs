using Model;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Api.Common;

namespace Web.Api.Controllers
{
    [RoutePrefix("values")]
    public class ValuesController : ApiController
    {
        ResponseHelper responseHealper = new ResponseHelper();
        //This is Express body example
        [Authorize]
        [Route("checkauth")]
        [HttpGet]
        public string CheckAuth() => "Token has been checked successfully..";

        [Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("HttpResponseMessage")]
        public HttpResponseMessage GetHttpResponseMessage()
        {
            return Request.CreateResponse(HttpStatusCode.OK, responseHealper.GetUser());
        }

        [Route("GetIHttpActionResult")]
        public IHttpActionResult GetIHttpActionResult()
        {
            return Ok(responseHealper.GetUser());
        }

        [Route("GetGenericActionResultUsingObject")]
        public IHttpActionResult GetObjectActionResult()
        {
            return new GenericActionResultUsingObject(responseHealper.GetUser(), ActionContext);
        }

        [Route("GetGenericActionResultUsingFunction")]
        public IHttpActionResult GetGenericActionResultUsingFunction()
        {
            return new GenericActionResultUsingFunction<UserInfo>(responseHealper.GetUserInfoFunction(), Request);
        }

        [Route("GetGenericActionResultUsingType")]
        public IHttpActionResult GetGenericActionResultUsingType()
        {
            return new GenericActionResultUsingType<UserInfo>(responseHealper.GetUser(), Request);
        }
    }
}
