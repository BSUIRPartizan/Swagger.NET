using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Api.Collector.Metadata.Api;
using Api.Collector.Metadata.Resolvers;
using NUnit.Framework;

namespace Api.Collector
{
    public class ApiCollector
    {
        private readonly IMetaDataResolver _metaDataResolver;

        public ApiCollector(IMetaDataResolver metaDataResolver)
        {
            _metaDataResolver = metaDataResolver;
        }

        public ApiCollectorResult Run(Type controllerBaseType, Assembly thisAssembly, List<String> filter)
        {
            var apiBundles = new List<ApiBundle>();
            int count = 0;

            foreach (Type type in thisAssembly.GetTypes())
            {
                if (type.InheritsFrom(controllerBaseType))
                {
                    ApiBundle metaData = _metaDataResolver.GetMetaData(type);
                    metaData.Type = type;
                    Assert.IsNotNull(metaData);
                    apiBundles.Add(metaData);
                    count++;
                }
            }
            
            ApiCollectorResult result = new ApiCollectorResult
            {
                Filter = FilterBundles(apiBundles, filter),
                ApiBundles = apiBundles.Where(x => !x.Skip).ToList(),
                FindApiCount = count
            };

            return result;
        }

        private List<Type> FilterBundles(List<ApiBundle> apiBundles, List<string> filter)
        {
            List<Type> skipThisType = new List<Type>();
            if (apiBundles == null)
                throw new ArgumentNullException("apiBundles");

            foreach (ApiBundle apiBundle in apiBundles)
            {
                Type type = apiBundle.Type;
                

                if (filter.Contains(type.ToString()))
                {
                    apiBundle.Skip = true;
                    skipThisType.Add(type);
                    Console.WriteLine("{0} - skip: {1}", type, apiBundle.Skip);
                    continue;
                }

                if (apiBundle.Apis.Count == 0)
                {
                    apiBundle.Skip = true;
                    skipThisType.Add(type);
                    Console.WriteLine("{0} - skip: {1}", type, apiBundle.Skip);
                }
                else
                {
                    Console.WriteLine("{0} - skip: {1}", type, apiBundle.Skip);
                }
            }

            return skipThisType;
        }
    }
}
