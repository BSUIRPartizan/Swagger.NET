using System;
using Api.Collector.Metadata.Api;

namespace Api.Collector.Metadata.Resolvers
{
    public interface IMetaDataResolver
    {
        ApiBundle GetMetaData(Type type);
    }
}