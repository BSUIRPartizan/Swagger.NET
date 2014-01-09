using System;
using Api.Collector.Metadata.Api;
using Api.Collector.Metadata.Models;

namespace Api.Collector.Metadata.Resolvers
{
    public class OperationParameterResolver : IOperationParameterResolver
    {
        private readonly IReflectionHelper reflectionHelper;

        public OperationParameterResolver(IReflectionHelper reflectionHelper)
        {
            this.reflectionHelper = reflectionHelper;
        }

        public OperationParameterResolver():this(new ReflectionHelper())
        {
        }

        public OperationParameter GetParameter(ApiInfo rootApiInfo, MetaDataOperationParameter parameter)
        {
            String url = rootApiInfo.RouteUrl;
            return new OperationParameter()
            {
                Name = parameter.Name,
                DataType = reflectionHelper.GetSwaggerPrimitiveParameterType(parameter.Type),
                ParamType = GetParamType(url, parameter),
                Required = IsRequired(url, parameter),
                // TODO: Use real parameter description. 
                Description = String.Format("TODO: Missing desc for parameter '{0}'.", parameter.Name)
            };
        }

        private string GetParamType(string url, MetaDataOperationParameter parameter)
        {
            if (url.Contains(String.Format("{{{0}}}", parameter.Name)))
            {
                return "path";
            }

            if (reflectionHelper.IsClass(parameter.Type))
            {
                return "body";
            }
            
            return "query";
            
        }

        private bool IsRequired(string url, MetaDataOperationParameter parameter)
        {
            return url.Contains(String.Format("{{{0}}}", parameter.Name));
        }
    }
}