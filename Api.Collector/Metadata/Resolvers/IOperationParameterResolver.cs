using Api.Collector.Metadata.Api;
using Api.Collector.Metadata.Models;

namespace Api.Collector.Metadata.Resolvers
{
    public interface IOperationParameterResolver
    {
        OperationParameter GetParameter(ApiInfo rootApiInfo, MetaDataOperationParameter parameter);
    }
}