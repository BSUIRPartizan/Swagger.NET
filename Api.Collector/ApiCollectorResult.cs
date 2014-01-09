using System;
using System.Collections.Generic;
using Api.Collector.Metadata.Api;

namespace Api.Collector
{
    public class ApiCollectorResult
    {
        public List<Type> Filter { get; set; }

        public List<ApiBundle> ApiBundles { get; set; }

        public int FindApiCount { get; set; }
    }
}