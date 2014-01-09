using System;
using System.Collections.Generic;
using System.Linq;
using Api.Collector.Metadata.Api;
using Api.Collector.Metadata.Resolvers;
using Api.Sample.Controllers;
using Api.Sample.Controllers.Base;
using NUnit.Framework;

namespace Api.Collector.Integration.Tests
{
    [TestFixture]
    public class MetaDataResolverTests
    {
        [Test]
        public void GetRoutePrefixTest()
        {
            IMetaDataResolver metaDataResolver = new MetaDataResolver();
            var apiBundle = metaDataResolver.GetMetaData(typeof (PHRGoalController));
            Assert.AreEqual(6, apiBundle.Apis.Count());
            Assert.AreEqual("/records/{recordId}/goals", apiBundle.Apis.First().Path);
            ValidateOperationsNames(apiBundle);
        }
        
        [Test]
        public void GetRouteByGetAttributeRoutePrefixTest()
        {
            IMetaDataResolver metaDataResolver = new MetaDataResolver();
            var apiBundle = metaDataResolver.GetMetaData(typeof(MedicationFulfillmentController));
            Assert.AreEqual(1, apiBundle.Apis.Count());
            Assert.AreEqual("/records/{recordid}/medicationfulfillment/{id}", apiBundle.Apis.First().Path);
            ValidateOperationsNames(apiBundle);
        }
  
        
        [Test]
        public void GetRoutesByGetAttributeAndByProutePrefixTest()
        {
            IMetaDataResolver metaDataResolver = new MetaDataResolver();
            var apiBundle = metaDataResolver.GetMetaData(typeof(LabResultController));
            Assert.AreEqual(7, apiBundle.Apis.Count());
            Assert.AreEqual("/records/{recordId}/lab/{Id}", apiBundle.Apis.First().Path);
            Assert.AreEqual("/records/{recordId}/labs/{testName}", apiBundle.Apis.Skip(1).First().Path);
            Console.WriteLine(apiBundle);
            ValidateOperationsNames(apiBundle);
            
        }
        
        [Test]
        public void GetRouteByGetAttributeAndByProutePrefixPOSTTest()
        {
            IMetaDataResolver metaDataResolver = new MetaDataResolver();
            var apiBundle = metaDataResolver.GetMetaData(typeof(LabResultController));
            Assert.AreEqual(7, apiBundle.Apis.Count());
            var api = apiBundle.Apis.First(x => x.Operations[0].HttpMethod == "POST");
            var parameters = api.Operations[0].Parameters;
            Assert.AreEqual(1, parameters.Count);
            Assert.AreEqual("LabResult", parameters[0].DataType);
            Assert.AreEqual("body", parameters[0].ParamType);
            
            Console.WriteLine(apiBundle);
            ValidateOperationsNames(apiBundle);
            
        }
        
        [Test]
        public void GetRoutesFromBaseClassTest()
        {
            IMetaDataResolver metaDataResolver = new MetaDataResolver();
            var apiBundle = metaDataResolver.GetMetaData(typeof(MessageFoldersController));
            Assert.AreEqual(5, apiBundle.Apis.Count());
            var apiBundleFirst = apiBundle.Apis.First();
            Assert.AreEqual("/api/messagefolders/{id}", apiBundleFirst.Path);
            Assert.IsNotNull(apiBundleFirst.Operations);
            Assert.AreEqual(1, apiBundleFirst.Operations.Count);
            Assert.AreEqual(1, apiBundleFirst.Operations.Count());
            ValidateOperationsNames(apiBundle);

            Console.WriteLine(apiBundle);
        }
        
        [Test]
        public void GetRoutesFromThrowExceptionControllerTest()
        {
            IMetaDataResolver metaDataResolver = new MetaDataResolver();
            var apiBundle = metaDataResolver.GetMetaData(typeof(ThrowExceptionController));
            Assert.AreEqual("testing/throwexception", apiBundle.PathRoot);
            Assert.AreEqual(2, apiBundle.Apis.Count());

            var firstApi = apiBundle.Apis[0];
            Assert.AreEqual("/testing/throwexception/{httpCode}", firstApi.Path);
            Assert.AreEqual(1, firstApi.Operations.Count);
            var getOperartion = firstApi.Operations[0];
            Assert.AreEqual("httpCode", getOperartion.Parameters[0].Name);
            Assert.AreEqual("int", getOperartion.Parameters[0].DataType);
            Assert.AreEqual("path", getOperartion.Parameters[0].ParamType);
            Assert.AreEqual(true, getOperartion.Parameters[0].Required);
           
            Assert.AreEqual("message", getOperartion.Parameters[1].Name);
            Assert.AreEqual("string", getOperartion.Parameters[1].DataType);
            Assert.AreEqual("query", getOperartion.Parameters[1].ParamType);
            Assert.AreEqual(false, getOperartion.Parameters[1].Required);

            var secondApi = apiBundle.Apis[1];
            Assert.AreEqual("/testing/throwruntimeexception/{message}", secondApi.Path);
            Assert.AreEqual(1, secondApi.Operations.Count);
            Assert.AreEqual("message", secondApi.Operations[0].Parameters[0].Name);

            ValidateOperationsNames(apiBundle);

            Console.WriteLine(apiBundle);
        }
        
        [Test]
        public void GetRoutesFromMicroCommunityControllerTest()
        {
            IMetaDataResolver metaDataResolver = new MetaDataResolver();
            var apiBundle = metaDataResolver.GetMetaData(typeof(MicroCommunityController));
            Assert.AreEqual("v2/ProcessMicrocommunities", apiBundle.PathRoot);
            Assert.AreEqual(2, apiBundle.Apis.Count());

            Assert.AreEqual("/v2/ProcessMicrocommunities", apiBundle.Apis[0].Path);
            Assert.AreEqual("/v2/ProcessMicrocommunities/All", apiBundle.Apis[1].Path);
            
            ValidateOperationsNames(apiBundle);

            Console.WriteLine(apiBundle);
        } 

        [Test]
        public void GetMarketplaceAppsControllerPagingParametersTest()
        {
            IMetaDataResolver metaDataResolver = new MetaDataResolver();
            var apiBundle = metaDataResolver.GetMetaData(typeof(MarketplaceAppsController));
            var apiInfo = apiBundle.Apis.FirstOrDefault(x => 
                x.RouteUrl == "/v1/group/{wlg}/marketplace/apps/{category}/{searchTerm}");
            Assert.IsNotNull(apiInfo);
            
            var operation = apiInfo.Operations.First();
            operation.Parameters.ForEach(x=>
                Console.WriteLine(x.Name));

            var limitParameter = operation.Parameters.FirstOrDefault(x => x.Name == "limit");
            Assert.IsNotNull(limitParameter);

            ValidateOperationsNames(apiBundle);

            Console.WriteLine(apiBundle);
        }
        
        [Test]
        public void GetMembershipTransactionControllerTest()
        {
            // /v2/group/memberships/{owner?}/{parent?}/{type?}/{offset?}/{limit?}/{order_by?}/{include_hidden=false}/{q?}/{groupCode?}/{groupCodeClimbTree=false}/{policyNumber?}/{flexField01?}/{flexField02?}/{flexField03?}/{flexField04?}/{flexField05?}/{flexField06?}/{flexField07?}/{flexField08?}/{flexField09?}/{flexField10?}
            IMetaDataResolver metaDataResolver = new MetaDataResolver();
            var apiBundle = metaDataResolver.GetMetaData(typeof(MembershipTransactionController));
            // AttributeRoute: v2/group/memberships/{owner?}/{parent?}/{type?}/{offset?}/{limit?}/{order_by?}/{include_hidden=false}/{q?}/{groupCode?}/{groupCodeClimbTree=false}/{policyNumber?}/{flexField01?}/{flexField02?}/{flexField03?}/{flexField04?}/{flexField05?}/{flexField06?}/{flexField07?}/{flexField08?}/{flexField09?}/{flexField10?}
            Assert.AreEqual("v2", apiBundle.PathRoot);
            Assert.AreEqual("/v2/group/memberships", apiBundle.Apis.First().Path);
            
            ValidateOperationsNames(apiBundle);

            Console.WriteLine(apiBundle);
        }

        private void ValidateOperationsNames(ApiBundle apiBundle)
        {
            List<String> operationNicknames = new List<String>();
            foreach (var api in apiBundle.Apis)
            {
                var operations = api.Operations;

                operations.ForEach(x =>
                {
                    Assert.IsFalse(operationNicknames.Contains(x.Nickname), String.Format("Nickname is not unique {0}", x.Nickname));
                    operationNicknames.Add(x.Nickname);
                });
            }
        }

        [Test]
        public void GetUrlShortenerControllerTest()
        {
            IMetaDataResolver metaDataResolver = new MetaDataResolver();
            var apiBundle = metaDataResolver.GetMetaData(typeof(UrlShortenerController));
            Assert.AreEqual("v1/utils/shorten", apiBundle.PathRoot);
            
            var apiInfo = apiBundle.Apis.First();
            Assert.AreEqual("/v1/utils/shorten", apiInfo.Path);

            var operation = apiInfo.Operations.First();

            Assert.IsNotNull(operation);
            var parameter = operation.Parameters.FirstOrDefault();
            Assert.IsNotNull(parameter);
            Assert.AreEqual("url", parameter.Name);

            ValidateOperationsNames(apiBundle);

            Console.WriteLine(apiBundle);
        }


     

    }
}