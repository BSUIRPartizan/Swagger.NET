using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting;
using AttributeRouting.Web.Http;

namespace Api.Sample.Controllers.Base
{
    [RoutePrefix("testing/throwexception")]
    public class ThrowExceptionController : ApiController
    {
        [HttpGet]
        [GET("{httpCode}/{?message}")]
        [System.Web.Http.AllowAnonymous]
        public HttpResponseMessage ThrowException(int httpCode, string message)
        {
            HttpStatusCode statusCode;
            if(Enum.TryParse<HttpStatusCode>(httpCode.ToString(CultureInfo.InvariantCulture), out statusCode))
            {
                return Request.CreateResponse((HttpStatusCode)httpCode, message);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, String.Format("Http status is incorrect: {0}", httpCode));
        }
        
        [HttpGet]
        [GET("testing/throwruntimeexception/{message}", IsAbsoluteUrl = true)]
        [System.Web.Http.AllowAnonymous]
        public HttpResponseMessage ThrowRuntimeException(string message)
        {
            throw new Exception(message, new Exception("Inner exception"));
        }
    }
}