using System.Web.Routing;
using NUnit.Framework;

namespace TestsRelevantToMvc5OnMono
{
    [TestFixture]
    public class SystemWebRoutingRouteCollectionTests
    {
        [Test]
        public void Should_have_AppendTrailingSlash_property_which_defaults_to_false()
        {
            var c = new RouteCollection();
            Assert.IsFalse (c.AppendTrailingSlash);
            c.AppendTrailingSlash = true;
            Assert.IsTrue (c.AppendTrailingSlash);
        }
        [Test]
        public void Should_have_LowercaseUrls_property_which_defaults_to_false()
        {
            var c = new RouteCollection();
            Assert.IsFalse(c.LowercaseUrls);
            c.LowercaseUrls = true;
            Assert.IsTrue(c.LowercaseUrls);
        }
    }
}