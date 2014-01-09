using System.Runtime.Serialization;

namespace Api.Collector.Tests.Models
{
    [DataContract]
    public class MarketplaceCategoryResult
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "category")]
        public string Category { get; set; }

        [DataMember(Name = "subcategory", EmitDefaultValue = false)]
        public string Subcategory { get; set; }

        [DataMember(Name = "parentId", EmitDefaultValue = false)]
        public int? ParentId { get; set; }
    }
}
