using System;
using Api.Collector.Metadata.Resolvers;
using NUnit.Framework;

namespace Api.Collector.Tests
{
    [TestFixture]
    public class ReflectionHelperTests
    {
        [Test]
        public void TypeIsClassTest()
        {
            IReflectionHelper reflectionHelper = new ReflectionHelper();
            Assert.IsTrue(reflectionHelper.IsClass(typeof(TestClass)));
        }
        
        [Test]
        public void TypeIsPrimitiveTest()
        {
            IReflectionHelper reflectionHelper = new ReflectionHelper();
            Assert.IsFalse(reflectionHelper.IsClass(typeof(int)));
        }
        
        [Test]
        public void TypeIsPrimitiveStringTest()
        {
            IReflectionHelper reflectionHelper = new ReflectionHelper();
            Assert.IsFalse(reflectionHelper.IsClass(typeof(String)));
        }
        
        [Test]
        public void TypeIsPrimitiveDoubleTest()
        {
            IReflectionHelper reflectionHelper = new ReflectionHelper();
            Assert.IsFalse(reflectionHelper.IsClass(typeof(Double)));
        } 
        
        [Test]
        public void TypeIsEnumTest()
        {
            IReflectionHelper reflectionHelper = new ReflectionHelper();
            Assert.IsFalse(reflectionHelper.IsClass(typeof(TestEnum)));
        }
        
        [Test]
        public void TypeIsStructurTest()
        {
            IReflectionHelper reflectionHelper = new ReflectionHelper();
            Assert.IsFalse(reflectionHelper.IsClass(typeof(TestStructur)));
        }

        enum TestEnum
        {
            First
        }
        
        struct TestStructur
        {
            
        }
 
        class TestClass
        {
        }
    }
}