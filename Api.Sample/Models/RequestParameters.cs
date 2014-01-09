using System.Runtime.Serialization;

namespace Api.Sample.Models
{
    [DataContract]
    public class RequestParameters
    {
        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public int? Limit { get; set; }

        [DataMember(Name = "offset", EmitDefaultValue = false)]
        public int? Offset { get; set; }

        [DataMember(Name = "order_by", EmitDefaultValue = false)]
        public string OrderBy { get; set; }

        [DataMember(Name = "q", EmitDefaultValue = false)]
        public string FilterQuery { get; set; }

        [DataMember(Name = "hl", EmitDefaultValue = false)]
        public string Language { get; set; }

        [DataMember(Name = "metadataType", EmitDefaultValue = false)]
        public ResponseMetadataType? MetadataType { get; set; }

        [IgnoreDataMember]
        public bool SkipOrdering { get; set; }

        [DataMember]
        public bool FieldWithoutNameInAttribute { get; set; }


        public bool IsEmpty
        {
            get
            {
                return Limit == null && Offset == null && OrderBy == null && FilterQuery == null && Language == null && MetadataType == null;
            }
        }
    }
}