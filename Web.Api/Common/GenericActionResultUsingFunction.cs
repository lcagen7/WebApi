using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Web.Api.Common
{
    public class GenericActionResultUsingFunction<T> : IHttpActionResult
    {
        private HttpRequestMessage _request;
        private Func<T> _func;

        public GenericActionResultUsingFunction(Func<T> func, HttpRequestMessage request)
        {
            this._func = func;
            this._request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(CreateResponse(_func, _request));

            //Direct create and return
            //return Task.FromResult(_request.CreateResponse(HttpStatusCode.OK, _func()));
        }

        public HttpResponseMessage CreateResponse(Func<T> func, HttpRequestMessage request)
        {
            HttpResponseMessage response;
            try
            {
                response = request.CreateResponse(HttpStatusCode.OK, func());
            }
            catch (HttpResponseException ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
            catch (Exception ex)
            {
                response=request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            return response;
        }

    }
}