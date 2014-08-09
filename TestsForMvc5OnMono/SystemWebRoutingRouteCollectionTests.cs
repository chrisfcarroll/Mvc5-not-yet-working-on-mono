using System.Web.Routing;
using NUnit.Framework;

namespace TestsRelevantToMvc5OnMono
{
    [TestFixture]
    public class SystemWebRoutingRouteCollectionTests
    {
#if NET_4_5
        [Test]
        public void Should_have_AppendTrailingSlash_property_which_defaults_to_false()
        {
            var expectedProperty = typeof(RouteCollection).GetProperty("AppendTrailingSlash");
            Assert.IsNotNull(expectedProperty);
        }
        [Test]
        public void Should_have_LowercaseUrls_property_which_defaults_to_false()
        {
            var expectedProperty = typeof(RouteCollection).GetProperty("LowercaseUrls");
            Assert.IsNotNull(expectedProperty);
        }
#endif
    }
}