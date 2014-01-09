using Api.Collector.Metadata.Api;

namespace Api.Collector.Metadata.Resolvers
{
    public interface IApiUrlResolver
    {
        string GetUrl(ApiInfo rootApiInfo);
    }
}