using System.Collections.Generic;
using Api.Collector.Metadata.Api;
using Api.Collector.Metadata.Resolvers;
using NUnit.Framework;

namespace Api.Collector.Tests
{
    [TestFixture]
    public class APiUrlResolverTests
    {
        [Test]
        public void GetUrlTest()
        {
            var apiInfo = new ApiInfo
            {
                RouteUrl =
                    "/v2/group/{personid}/memberships/{owner?}/{limit}/{order_by?}/{include_hidden=false}/{q?}/",
                Operations = new List<Operation>(new[]
                {
                    new Operation
                    {
                        Parameters = new List<OperationParameter>(new[]
                        {
                            new OperationParameter
                            {
                                Name = "personid"
                            },
                            new OperationParameter
                            {
                                Name = "owner"
                            },
                            new OperationParameter
                            {
                                Name = "order_by"
                            },
                            new OperationParameter
                            {
                                Name = "limit"
                            },
                            new OperationParameter
                            {
                                Name = "include_hidden"
                            },
                            new OperationParameter
                            {
                                Name = "q"
                            }
                        })
                    }
                })
            };

            IApiUrlResolver metaDataResolver = new ApiUrlResolver();
            Assert.AreEqual("/v2/group/{personid}/memberships/{limit}", metaDataResolver.GetUrl(apiInfo));
        }
    }
}