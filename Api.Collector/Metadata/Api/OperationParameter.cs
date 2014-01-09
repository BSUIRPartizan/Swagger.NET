using System;
using Newtonsoft.Json;

namespace Api.Collector.Metadata.Api
{
    public class OperationParameter
    {
        [JsonProperty("description")]
        public String Description { get; set; }

        [JsonProperty("paramType")]
        public String ParamType { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("allowMultiple")]
        public bool AllowMultiple { get; set; }

        [JsonProperty("dataType")]
        public String DataType { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }
    }
}