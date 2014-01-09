using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Api.Collector.Metadata.Api
{
    public class ApiRoot
    {
        public ApiRoot()
        {
            Apis = new List<ApiInfo>();
        }

        [JsonProperty("basePath", Order = 3)]
        public String BasePath
        {
            get;
            set;
        }

        [JsonProperty("resourcePath", Order = 4)]
        public String ResourcePath
        {
            get;
            set;
        }

        [JsonProperty("apis", Order = 6)]
        public List<ApiInfo> Apis
        {
            get;
            set;
        }

        [JsonProperty("apiVersion", Order = 1)]
        public String ApiVersion { get; set; }

        [JsonProperty("swaggerVersion", Order = 2)]
        public String SwaggerVersion { get; set; }
    }
}