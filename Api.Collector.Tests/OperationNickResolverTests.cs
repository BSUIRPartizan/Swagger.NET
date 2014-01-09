using System;
using System.Linq;
using Api.Collector.Metadata.Models;
using Api.Collector.Metadata.Resolvers;
using NUnit.Framework;

namespace Api.Collector.Tests
{
    [TestFixture]
    public class OperationNickResolverTests
    {
        [Test]
        public void GenerateNicknameTest()
        {
            IOperationNicknameResolver operationNicknameResolver = new OperationNicknameResolver();
            Type mainType = typeof (OperationNickResolverTests);

            Assert.AreEqual("OperationNickResolverTests_TestMethod",
                operationNicknameResolver.GetOperationNickname(mainType, mainType.GetMethod("TestMethod"), null));
        }
        
        [Test]
        
        public void GenerateUniqueNicknameTest()
        {
            IOperationNicknameResolver operationNicknameResolver = new OperationNicknameResolver();
            Type mainType = typeof (OperationNickResolverTests);

            var method = mainType.GetMethod("TestMethod");
            Assert.AreEqual("OperationNickResolverTests_TestMethod",
                operationNicknameResolver.GetOperationNickname(mainType, method, null));
            
            Assert.AreEqual("OperationNickResolverTests_TestMethod_2",
                operationNicknameResolver.GetOperationNickname(mainType, method, null));
        }

        [Test]
        public void GenerateNicknameForMethodWithParameterTest()
        {
            IOperationNicknameResolver operationNicknameResolver = new OperationNicknameResolver();
            Type mainType = typeof (OperationNickResolverTests);

            Assert.AreEqual("OperationNickResolverTests_GenerateNicknameForMethodWithParameterTest_IsValidCount",
                operationNicknameResolver.GetOperationNickname(mainType,
                    mainType.GetMethod("GenerateNicknameForMethodWithParameterTest"),
                    new[]
                    {
                        new MetaDataOperationParameter {Name = "isValid", Type = typeof (bool)},
                        new MetaDataOperationParameter {Name = "count", Type = typeof (int)}
                    }.ToList()));
        }
        
        [Test]
        public void GenerateUniqueNicknameForMethodWithParameterTest()
        {
            IOperationNicknameResolver operationNicknameResolver = new OperationNicknameResolver();
            Type mainType = typeof (OperationNickResolverTests);

            Assert.AreEqual("OperationNickResolverTests_GenerateNicknameForMethodWithParameterTest_IsValidCount",
                operationNicknameResolver.GetOperationNickname(mainType,
                    mainType.GetMethod("GenerateNicknameForMethodWithParameterTest"),
                    new[]
                    {
                        new MetaDataOperationParameter {Name = "isValid", Type = typeof (bool)},
                        new MetaDataOperationParameter {Name = "count", Type = typeof (int)}
                    }.ToList()));
            
            Assert.AreEqual("OperationNickResolverTests_GenerateNicknameForMethodWithParameterTest_IsValidCount_2",
                operationNicknameResolver.GetOperationNickname(mainType,
                    mainType.GetMethod("GenerateNicknameForMethodWithParameterTest"),
                    new[]
                    {
                        new MetaDataOperationParameter {Name = "isValid", Type = typeof (bool)},
                        new MetaDataOperationParameter {Name = "count", Type = typeof (int)}
                    }.ToList()));
        }

        public void TestMethod()
        {
        }

        public void TestMethodWithParameters(bool isValid, int count)
        {
        }
    }
}