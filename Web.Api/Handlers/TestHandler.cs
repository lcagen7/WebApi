using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Web.Api.Handlers
{
    public class TestHandler : DelegatingHandler
    {
        protected TestHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        {
        }
    }
}