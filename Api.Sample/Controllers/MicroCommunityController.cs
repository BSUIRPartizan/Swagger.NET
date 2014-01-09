using System.Net;
using System.Net.Http;
using Api.Sample.Controllers.Base;
using AttributeRouting;
using AttributeRouting.Web.Http;

namespace Api.Sample.Controllers
{
    [RoutePrefix("v2/ProcessMicrocommunities")]
    public class MicroCommunityController : BaseApiController
    {
        [GET("")]
        public HttpResponseMessage GetProcessMicrocommunities()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [GET("All")]
        public HttpResponseMessage GetProcessAllMicroCommunities()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}