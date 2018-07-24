using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Web.Api.Common;

namespace Web.Api.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("Token")]
    public class TokenController : ApiController
    {
        /// <summary>
        /// Get Refresh Token.
        /// </summary>
        /// <returns></returns>
        /// GET api/Token/Refresh
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get(string loginId, string password)
        {
            Services.TokenService ts = new Services.TokenService();
            string settingsValue = ts.GetToken(loginId, password);
            if (settingsValue == null || string.IsNullOrEmpty(settingsValue.ToString()))
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Invalid username or password.");
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, settingsValue);
            }
            //return new GenericActionResultUsingObject(settingsValue, ActionContext);
        }
    }
}