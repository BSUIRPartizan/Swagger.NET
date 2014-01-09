using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Web.Http;
using Api.Collector.Metadata.Models;

namespace Api.Collector.Metadata.Resolvers
{
    public class OperationParameterFactory : IOperationParameterFactory
    {
        private IReflectionHelper reflectionHelper;

        public OperationParameterFactory():this(new ReflectionHelper())
        {
        }

        public OperationParameterFactory(IReflectionHelper reflectionHelper)
        {
            this.reflectionHelper = reflectionHelper;
        }

        public IEnumerable<MetaDataOperationParameter> CreateParameter(ParameterInfo parameterInfo)
        {
            FromUriAttribute[] attributes = parameterInfo.GetCustomAttributes(typeof(FromUriAttribute), true)
                as FromUriAttribute[];
            if (attributes != null && attributes.Any() && reflectionHelper.IsClass(parameterInfo.ParameterType))
                return GetListParameters(parameterInfo);

            return new[]
            {
                new MetaDataOperationParameter
                {
                    Name = parameterInfo.Name,
                    Type = GetFixedType(parameterInfo.ParameterType),
                }
            };
        }

        private IEnumerable<MetaDataOperationParameter> GetListParameters(ParameterInfo parameterInfo)
        {
            List<MetaDataOperationParameter> operationParameters = new List<MetaDataOperationParameter>();
            foreach (var fieldInfo in parameterInfo.ParameterType.GetProperties())
            {
                var dataMemberAttr = fieldInfo.GetCustomAttributes(typeof(DataMemberAttribute), true).FirstOrDefault();
                if (dataMemberAttr != null)
                {
                    String name = ((DataMemberAttribute) dataMemberAttr).Name;
                    if (String.IsNullOrEmpty(name))
                    {
                        name = fieldInfo.Name;
                    }

                    operationParameters.Add(new MetaDataOperationParameter
                        {
                            Name = name,
                            Type = GetFixedType(fieldInfo.PropertyType),
                        });
                }
            }

            return operationParameters;
        }

        private Type GetFixedType(Type propertyType)
        {
            var nullableType = Nullable.GetUnderlyingType(propertyType);
            return nullableType ?? propertyType;
        }
    }
}