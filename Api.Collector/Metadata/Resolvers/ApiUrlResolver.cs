using System;
using Api.Collector.Metadata.Api;

namespace Api.Collector.Metadata.Resolvers
{
    public class ApiUrlResolver : IApiUrlResolver
    {
        public string GetUrl(ApiInfo rootApiInfo)
        {
            String url = rootApiInfo.RouteUrl;
            foreach (OperationParameter operationParameter in rootApiInfo.Operations[0].Parameters)
            {
                url = url
                    .Replace(String.Format("{{?{0}}}", operationParameter.Name), "")
                    .Replace(String.Format("{{{0}?}}", operationParameter.Name), "");

                url = RemoveParameterWithConstrains(url, operationParameter)
                    .Replace("//", "/");
            }

            return url.TrimEnd('/');
        }

        private String RemoveParameterWithConstrains(string url, OperationParameter operationParameter)
        {
            String parameterName = operationParameter.Name;
            String searchTemplate = String.Format("{{{0}=", parameterName);
            int startIndex = url.IndexOf(searchTemplate, StringComparison.Ordinal);
            if (startIndex > -1)
            {
                int endIndex = url.IndexOf("}", startIndex, StringComparison.Ordinal);
                if (endIndex > -1)
                    url = url.Substring(0, startIndex) + url.Substring(endIndex + 1);
            }

            return url;
        }
    }
}