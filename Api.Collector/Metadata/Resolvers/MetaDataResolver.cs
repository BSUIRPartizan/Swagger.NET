using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using Api.Collector.Metadata.Api;
using Api.Collector.Metadata.Models;
using AttributeRouting;
using AttributeRouting.Web.Http;

namespace Api.Collector.Metadata.Resolvers
{
    public class MetaDataResolver : IMetaDataResolver
    {
        private readonly IOperationNicknameResolver _operationNicknameResolver;
        private readonly IApiUrlResolver _apiUrlResolver;
        private readonly IOperationParameterResolver _operationParameterRelolver;
        private readonly IOperationParameterFactory _operationParameterFactory;

        public MetaDataResolver()
            : this(new OperationNicknameResolver(), new ApiUrlResolver(), new OperationParameterResolver(), new OperationParameterFactory())
        {
        }

        public MetaDataResolver(IOperationNicknameResolver operationNicknameResolver, IApiUrlResolver apiUrlResolver, 
            IOperationParameterResolver operationParameterRelolver, IOperationParameterFactory operationParameterFactory)
        {
            _operationNicknameResolver = operationNicknameResolver;
            _apiUrlResolver = apiUrlResolver;
            _operationParameterRelolver = operationParameterRelolver;
            this._operationParameterFactory = operationParameterFactory;
        }

        public ApiBundle GetMetaData(Type type)
        {
            return GetApiInfo(type);
        }

        private ApiBundle GetApiInfo(Type type)
        {
            var apiInfos = new List<ApiInfo>();
            var apiBundle = new ApiBundle
            {
                Apis = apiInfos
            };

            object[] attributes = type.GetCustomAttributes
                (typeof (RoutePrefixAttribute), false);

            if (attributes.Length > 0)
            {
                foreach (object attr in attributes)
                {
                    string url = ((RoutePrefixAttribute) attr).Url;
                    apiBundle.PathRoot = url;
                }
            }

            foreach (MethodInfo method in type.GetMethods())
            {
                var methodAttributes =
                    method.GetCustomAttributes(typeof (HttpRouteAttribute), false) as HttpRouteAttribute[];
                foreach (HttpRouteAttribute methodAttribute in methodAttributes)
                {
                    ApiInfo rootApiInfo = GetRootApiInfo(apiBundle, apiInfos, methodAttribute);
                    List<MetaDataOperationParameter> parameters = GetParameters(method);
                    AddOperation(_operationNicknameResolver.GetOperationNickname(type, method, parameters), rootApiInfo,
                        methodAttribute, parameters);
                    rootApiInfo.Path = _apiUrlResolver.GetUrl(rootApiInfo);
                }
            }

            return apiBundle;
        }

        private List<MetaDataOperationParameter> GetParameters(MethodInfo method)
        {
            var operationParameters = new List<MetaDataOperationParameter>();
            foreach (ParameterInfo parameterInfo in method.GetParameters())
            {
                operationParameters.AddRange(_operationParameterFactory.CreateParameter(parameterInfo));
            }

            return operationParameters;
        }

        private void AddOperation(string nickname, ApiInfo rootApiInfo, HttpRouteAttribute methodAttribute, IEnumerable<MetaDataOperationParameter> parameters)
        {
            var operation = new Operation
            {
                HttpMethod = GetHttpMethod(methodAttribute),
                Nickname = nickname,
                Parameters = new List<OperationParameter>()
            };
            rootApiInfo.Operations.Add(operation);

            foreach (var parameter in parameters)
            {
                operation.Parameters.Add(_operationParameterRelolver.GetParameter(rootApiInfo, parameter));
            }
        }

        private string GetHttpMethod(HttpRouteAttribute methodAttribute)
        {
            if (methodAttribute is GETAttribute)
            {
                return HttpMethod.Get.ToString().ToUpper();
            }
            if (methodAttribute is POSTAttribute)
            {
                return HttpMethod.Post.ToString().ToUpper();
            }

            if (methodAttribute is PUTAttribute)
            {
                return HttpMethod.Put.ToString().ToUpper();
            }
            if (methodAttribute is DELETEAttribute)
            {
                return HttpMethod.Delete.ToString().ToUpper();
            }

            return null;
        }

        private ApiInfo GetRootApiInfo(ApiBundle apiBundle, List<ApiInfo> apiInfos, HttpRouteAttribute methodAttribute)
        {
            HttpRouteAttribute route = methodAttribute;
            ApiInfo apiInfo;
            if (route.IsAbsoluteUrl)
            {
                apiInfo = new ApiInfo
                {
                    RouteUrl = GetFixedUrl(route.RouteUrl)
                };
                apiInfos.Add(apiInfo);
                return apiInfo;
            }

            apiInfo = new ApiInfo
            {
                RouteUrl = GetRoute(apiBundle.PathRoot, route.RouteUrl)
            };
            apiInfos.Add(apiInfo);

            return apiInfo;
        }

        private string GetRoute(string pathRoot, string routeUrl)
        {
            if (String.IsNullOrEmpty(pathRoot))
                return GetFixedUrl(String.Format("{0}", routeUrl.Trim('/')));
            return GetFixedUrl(String.Format("{0}/{1}", pathRoot.Trim('/'), routeUrl.Trim('/')));
        }

        private string GetFixedUrl(string url)
        {
            return String.Format("/{0}", url.Trim('/'));
        }
    }
}