using System.Web.Http;

namespace Api.Collector.Tests.Controllers.Base
{
    public abstract class BaseBOApiV2Controller<TBO, T> : ApiController
        where TBO : class
        where T : class
    {
    }
}