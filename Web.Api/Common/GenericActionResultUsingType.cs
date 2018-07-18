using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Web.Api.Common
{
    public class GenericActionResultUsingType<T> : IHttpActionResult
    {
        private HttpRequestMessage _request;
        private T _value;

        public GenericActionResultUsingType(T value, HttpRequestMessage request)
        {
            this._value = value;
            this._request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(CreateResponse(_value, _request));

            //Direct create and return
            //return Task.FromResult(_request.CreateResponse(HttpStatusCode.OK, _func()));
        }

        public HttpResponseMessage CreateResponse(T value, HttpRequestMessage request)
        {
            HttpResponseMessage response;
            try
            {
                response = request.CreateResponse(HttpStatusCode.OK, value);
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