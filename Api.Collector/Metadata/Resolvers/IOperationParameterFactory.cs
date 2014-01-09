using System.Collections.Generic;
using System.Reflection;
using Api.Collector.Metadata.Models;

namespace Api.Collector.Metadata.Resolvers
{
    public interface IOperationParameterFactory
    {
        IEnumerable<MetaDataOperationParameter> CreateParameter(ParameterInfo parameterInfo);
    }
}