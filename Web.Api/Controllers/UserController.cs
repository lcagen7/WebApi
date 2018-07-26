using Model;
using System.Collections.Generic;
using System.Web.Http;
using Web.Api.Common;
using System.Web.Http.Cors;

namespace Web.Api.Controllers
{
    [RoutePrefix("User")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        ResponseHelper responseHealper = new ResponseHelper();

        [Route("GetUser/{loginid}")]
        [HttpGet]
        public IHttpActionResult GetUser(string loginId)
        {
            return new GenericActionResultUsingType<UserInfo>(responseHealper.GetUser(loginId), Request);
        }

        [Route("GetAllUsers")]
        [HttpGet, HttpOptions]
        public IHttpActionResult GetAllUsers()
        {
            return new GenericActionResultUsingType<IList<UserInfo>>(responseHealper.GetAllUsers(), Request);
        }

        [Route("Updateuser")]
        [HttpPut, HttpOptions]
        public IHttpActionResult UpdatUser(UserInfo userInfo)
        {
            return new GenericActionResultUsingType<UserInfo>(responseHealper.UpdateUser(userInfo), Request);
        }
    }
}
