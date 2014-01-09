using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Api.Collector.Tests.Models
{
    [DataContract]
    public class MarketplaceAppShortResult
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "platformIndependentId")]
        public string PlatformIndependentUID { get; set; }

        [DataMember(Name = "app")]
        public string Name { get; set; }

        [DataMember(Name = "category")]
        public List<MarketplaceCategoryResult> Categories { get; set; }

        [DataMember(Name = "developer")]
        public string Company { get; set; }

        [DataMember(Name = "thumbURL")]
        public string Icon { get; set; }

        [DataMember(Name = "thumbCssClass")]
        public string IconCssClassName { get; set; }

        [DataMember(Name = "blurb")]
        public string Blurb { get; set; }

        [DataMember(Name = "mWellthCertificationLevel")]
        public int MWellthCertificationLevel { get; set; }

        [DataMember(Name = "ratingMWellth")]
        public double RatingMWellth { get; set; }

        [DataMember(Name = "ratingCommunity")]
        public double RatingCommunity { get; set; }

        [DataMember(Name = "ratingUserStars")]
        public double RatingUser { get; set; }

        [DataMember(Name = "ratingUserCnt")]
        public int UserRatings { get; set; }

        [DataMember(Name = "keywords")]
        public string Keywords { get; set; }

        [DataMember(Name = "isInstalled")]
        public bool IsInstalled { get; set; }

        [DataMember(Name = "points")]
        public double InstallPointValue { get; set; }
    
        [DataMember(Name = "os")]
        public String Os { get; set; }

        [DataMember(Name = "description")]
        public string DescriptionGeneral { get; set; }

        [DataMember(Name = "appStoreURL")]
        public string AppStoreUrl { get; set; }

        [DataMember(Name = "personalRating")]
        public double? RatingPersonal { get; set; }

        [DataMember(Name = "mostPopularWeight")]
        public double? MostPopularWeight { get; set; }

        [DataMember(Name = "expertWeight")]
        public double? ExpertWeight { get; set; }

        [DataMember(Name = "recommendedWeight")]
        public double? RecommendedWeight { get; set; }
    }
}
