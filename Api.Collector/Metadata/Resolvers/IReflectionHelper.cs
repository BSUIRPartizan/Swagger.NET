using System;

namespace Api.Collector.Metadata.Resolvers
{
    public interface IReflectionHelper
    {
        bool IsClass(Type type);
        string GetSwaggerPrimitiveParameterType(Type type);
    }
}