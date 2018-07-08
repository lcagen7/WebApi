using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Web.Api.Common
{
    public class GenericActionResultUsingObject : IHttpActionResult
    {
        readonly object _value;
        readonly HttpRequestMessage _request;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="actionContext"></param>
        public GenericActionResultUsingObject(object value, HttpActionContext actionContext)
        {
            _value = value;
            _request = actionContext.Request;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            try
            {
                if (_value == null || string.IsNullOrEmpty(_value.ToString()))
                {
                    return Task.FromResult(_request.CreateResponse(HttpStatusCode.NotFound));
                }
                var response = _request.CreateResponse(HttpStatusCode.OK, _value);
                return Task.FromResult(response);

            }
            catch (Exception ex)
            {
                return Task.FromResult(_request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }

        }
    }

}