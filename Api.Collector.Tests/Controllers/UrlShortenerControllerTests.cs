using System.Web.Http;
using Api.Collector.Tests.Models;
using AttributeRouting;
using AttributeRouting.Web.Http;

namespace Api.Collector.Tests.Controllers
{
    [RoutePrefix("v1/utils/shorten")]
    public class UrlShortenerControllerTests : ApiController
    {
        [AllowAnonymous]
        [GET("")]
        public SimpleResult<string> Get([FromUri] string url)
        {
            return new SimpleResult<string>()
            {
                Data = url
            };
        }
    }



    //[RoutePrefix("v1/marketplace/apps")]
}