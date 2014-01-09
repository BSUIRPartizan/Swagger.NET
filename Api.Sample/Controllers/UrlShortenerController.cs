using System.IO;
using System.Net;
using System.Web;
using System.Web.Http;
using Api.Collector.Tests.Models;
using AttributeRouting;
using AttributeRouting.Web.Http;

namespace Api.Sample.Controllers
{
    [RoutePrefix("v1/utils/shorten")]
    public class UrlShortenerController : ApiController
    {
        [AllowAnonymous]
        [GET("")]
        public SimpleResult<string> Get([FromUri] string url)
        {
            var encodedUrl = GetFullUrl(url);

            var request = WebRequest.Create(encodedUrl);
            var response = request.GetResponse();
            var stream = response.GetResponseStream();

            if (stream == null)
            {
                return null;
            }

            using (var reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();

                return new SimpleResult<string>(result);
            }
        }

        private string GetFullUrl(string url)
        {
            var encodedUrl = HttpUtility.UrlEncode(url);

            var result = string.Format("http://tinyurl.com/api-create.php?url={0}", encodedUrl);

            return result;
        }
    }
}