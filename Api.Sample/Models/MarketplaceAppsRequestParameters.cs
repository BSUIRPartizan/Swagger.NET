using System;
using System.Runtime.Serialization;

namespace Api.Sample.Models
{
    [DataContract]
    public class MarketplaceAppsRequestParameters
    {
        [DataMember]
        public String Parameter { get; set; }
    }
}