using System;
using System.Collections.Generic;
using System.IO;
using Api.Collector;
using NUnit.Framework;

namespace Api.Swagger.Generator.Runner
{
    public class ApiValidator
    {
        public void ValidateData(List<String> filter, ApiCollectorResult result)
        {
            List<Type> skipThisType = result.Filter;
            int count = result.ApiBundles.Count + skipThisType.Count;
            //Assert.AreEqual(230, count);

            Console.WriteLine("ApiController counters are {0}.", count);
            Console.WriteLine("These controller were skipped: ");

            skipThisType.ForEach(Console.WriteLine);

            Assert.AreEqual(result.FindApiCount, count);
        }

        public List<String> GetFilter()
        {
            return new List<String>(File.ReadAllLines("SkipTypes.txt"));
        }
    }
}