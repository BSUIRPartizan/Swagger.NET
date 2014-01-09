using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Api.Collector.Metadata.Api
{
    public class ApiBundle
    {
        [JsonProperty("apis")]
        public List<ApiInfo> Apis
        {
            get;
            set;
        }

        [JsonIgnore]
        public string PathRoot { get; set; }

        [JsonIgnore]
        public Type Type { get; set; }

        [JsonIgnore]
        public bool Skip { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Apis.ForEach(x=>stringBuilder.AppendLine(x.ToString()));
            return stringBuilder.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }
    }
}