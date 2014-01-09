using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Api.Collector.Metadata.Api
{
    public class ApiInfo
    {
        public ApiInfo()
        {
            Operations = new List<Operation>();
            // TODO: Complete api description.
            Description = "TODO: Missing desc for this api.";
        }
        
        [JsonProperty("path")]
        public String Path { get; set; }

        [JsonIgnore()]
        public String RouteUrl { get; set; }


        [JsonProperty("description")]
        public String Description { get; set; }

        [JsonProperty("operations")]
        public List<Operation> Operations { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
