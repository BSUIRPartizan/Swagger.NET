using Api.Collector.Metadata.Resolvers;
using NUnit.Framework;

namespace Api.Collector.Tests
{
    [TestFixture]
    public class UrlValidatorTests
    {
        [TestCase("/v2/group/{personid}/memberships", Result = true)]
        [TestCase("v2/group/{personid}/memberships", Result = false)]
        [TestCase("/v2\\group/{personid}/memberships", Result = false)]
        [TestCase("/v2/group/{?personid}/memberships", Result = false)]
        [TestCase("/v2/group/{personid?}/memberships", Result = false)]
        [TestCase("/v2/group/{personid}/memberships/{isHidden=false}", Result = false)]
        [TestCase("/v2/group/{personid}/memberships?isHidden=false", Result = false)]
        public bool ValidteUrlTest(string url)
        {
            IUrlValidator ulUrlValidator = new SwaggerApiUrlValidator();
            return ulUrlValidator.Validate(url);
        }
    }
}