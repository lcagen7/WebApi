using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Web.Api.Common;

namespace Web.Api.Controllers
{
    public class TokenController : ApiController
    {
        /// <summary>
        /// Get Refresh Token.
        /// </summary>
        /// <returns></returns>
        /// GET api/Token/Refresh
        [HttpGet]
        //[Route("~/api/Token/Get")]
        public IHttpActionResult Get(string loginId, string password)
        {
            Services.TokenService ts = new Services.TokenService();
            string settingsValue = ts.GetToken(loginId, password);
            return new ApiActionResult(settingsValue, ActionContext);
        }
    }
}