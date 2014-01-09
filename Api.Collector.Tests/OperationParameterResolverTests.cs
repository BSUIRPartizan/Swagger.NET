using Api.Collector.Metadata.Api;
using Api.Collector.Metadata.Models;
using Api.Collector.Metadata.Resolvers;
using Api.Collector.Tests.Models;
using NUnit.Framework;

namespace Api.Collector.Tests
{
    [TestFixture]
    public class OperationParameterResolverTests
    {
        private OperationParameterResolver operationParameterResolver;

        private ApiInfo apiInfo;
        
        [SetUp]
        public void SetUP()
        {
            apiInfo = new ApiInfo
            {
                RouteUrl =
                    "/v2/group/{personid}/memberships/{owner?}/{limit}/{order_by?}/{include_hidden=false}/{q?}"
            };

            operationParameterResolver = new OperationParameterResolver();

        }
        
        [Test]
        public void GetParemeterTest()
        {
            MetaDataOperationParameter parameter = new MetaDataOperationParameter()
            {
                Name = "owner",
                Type = typeof(string)
            };
            
            var operationParameter = operationParameterResolver.GetParameter(apiInfo, parameter);
            Assert.AreEqual("owner", operationParameter.Name);
            Assert.AreEqual(false, operationParameter.Required);
            Assert.AreEqual("query", operationParameter.ParamType);
            Assert.AreEqual("string", operationParameter.DataType);
            
        }
        
        [Test]
        public void GetIntTypeParemeterTest()
        {
            MetaDataOperationParameter parameter = new MetaDataOperationParameter()
            {
                Name = "owner",
                Type = typeof(int)
            };
            
            var operationParameter = operationParameterResolver.GetParameter(apiInfo, parameter);
            Assert.AreEqual("int", operationParameter.DataType);
        }
        
        [Test]
        public void GetParemeterWithTemporaryApiDescTest()
        {
            apiInfo = new ApiInfo
            {
                RouteUrl =
                    "/v2/group/{personid}/memberships/{owner?}/{limit}/{order_by?}/{include_hidden=false}/{q?}"
            };

            Assert.AreEqual("TODO: Missing desc for this api.", apiInfo.Description);
        }
        
        [Test]
        public void GetParemeterWithTemporaryDescTest()
        {
            MetaDataOperationParameter parameter = new MetaDataOperationParameter()
            {
                Name = "owner",
                Type = typeof(int)
            };
            
            var operationParameter = operationParameterResolver.GetParameter(apiInfo, parameter);
            Assert.AreEqual("TODO: Missing desc for parameter 'owner'.", operationParameter.Description);
        }
        
        [Test]
        public void GetParemeterWithBodyParameterTest()
        {
            MetaDataOperationParameter parameter = new MetaDataOperationParameter()
            {
                Name = "owner",
                Type = typeof(Account)
            };
            
            var operationParameter = operationParameterResolver.GetParameter(apiInfo, parameter);
            Assert.AreEqual("Account", operationParameter.DataType);
            Assert.AreEqual("body", operationParameter.ParamType);
        }
    }
}
