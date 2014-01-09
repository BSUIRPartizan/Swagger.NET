using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Api.Collector.Metadata.Api
{
    public class Operation
    {
        [JsonProperty("httpMethod")]
        public String HttpMethod { get; set; }

        [JsonProperty("nickname")]
        public String Nickname { get; set; }

        [JsonProperty("parameters")]
        public List<OperationParameter> Parameters { get; set; }
    }
}