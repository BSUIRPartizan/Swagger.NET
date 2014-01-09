using System.Runtime.Serialization;

namespace Api.Collector.Tests.Models
{
    [DataContract]
    public class ApiResponseMetadata
    {
        [DataMember(Name = "next", EmitDefaultValue = false)]
        public string NextPage { get; set; }

        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public int? Limit { get; set; }

        [DataMember(Name = "offset", EmitDefaultValue = false)]
        public int? Offset { get; set; }

        [DataMember(Name = "order_by", EmitDefaultValue = false)]
        public string OrderBy { get; set; }

        [DataMember(Name = "fields", EmitDefaultValue = false)]
        public string[] Fields { get; set; }

        [DataMember(Name = "total", EmitDefaultValue = false)]
        public long Total { get; set; }
    }
}