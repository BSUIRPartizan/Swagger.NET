using System;
using System.Collections.Generic;
using System.Linq;
using Api.Collector.Metadata.Models;
using Api.Collector.Metadata.Resolvers;
using Api.Collector.Tests.Controllers;
using Api.Collector.Tests.Models;
using NUnit.Framework;

namespace Api.Collector.Tests
{
    [TestFixture]
    public class OperationParameterFactoryTests
    {
        [Test]
        public void CreateParameter2Test()
        {
            IOperationParameterFactory operationParameterFactory = new OperationParameterFactory();
            var classType = typeof(UrlShortenerControllerTests);
            var methodInfo = classType.GetMethod("Get");
            Assert.IsNotNull(methodInfo);
            var refParameters = methodInfo.GetParameters();
            var refParameter = refParameters.FirstOrDefault(x => x.Name == "url");
            Assert.IsNotNull(refParameter);

            var parameters = operationParameterFactory.CreateParameter(refParameter);
            Assert.IsNotNull(parameters);
            Assert.AreEqual(1, parameters.Count());
            var parameter = parameters.First();
            Assert.AreEqual("url", parameter.Name);
        }

        [Test]
        public void CreateParameterTest()
        {
            IOperationParameterFactory operationParameterFactory = new OperationParameterFactory();
            var classType = typeof(MarketplaceAppsControllerTest);
            var methodInfo = classType.GetMethod("GetForOrgUnit");
            Assert.IsNotNull(methodInfo);
            var refParameters = methodInfo.GetParameters();
            var refParameter = refParameters.FirstOrDefault(x => x.Name == "pagingParameter");
            Assert.IsNotNull(refParameter);

            IEnumerable<MetaDataOperationParameter> parameters = operationParameterFactory.CreateParameter(refParameter);
            Assert.IsNotNull(parameters);

            IEnumerable<MetaDataOperationParameter> metaDataOperationParameters = parameters as MetaDataOperationParameter[] 
                ?? parameters.ToArray();
            foreach (var metaDataOperationParameter in metaDataOperationParameters)
            {
                Console.WriteLine(metaDataOperationParameter.Name);
            }

            ValidateParameter(metaDataOperationParameters, "limit", typeof(int));
            ValidateParameter(metaDataOperationParameters, "offset", typeof(int));
            ValidateParameter(metaDataOperationParameters, "order_by", typeof(string));
            ValidateParameter(metaDataOperationParameters, "q", typeof(string));
            ValidateParameter(metaDataOperationParameters, "hl", typeof(string));
            ValidateParameter(metaDataOperationParameters, "FieldWithoutNameInAttribute", typeof(bool));
            ValidateParameter(metaDataOperationParameters, "metadataType", typeof(ResponseMetadataType));
            Assert.AreEqual(7, metaDataOperationParameters.Count());
        }

        private void ValidateParameter(IEnumerable<MetaDataOperationParameter> metaDataOperationParameters, string name, 
            Type parameterType)
        {
            var parameter = metaDataOperationParameters.FirstOrDefault(x => x.Name == name);
            Assert.IsNotNull(parameter, String.Format("Parameter '{0}' is not defined.", name));
            Assert.AreEqual(name, parameter.Name);
            Assert.AreEqual(parameterType, parameter.Type);
        }
    }
}