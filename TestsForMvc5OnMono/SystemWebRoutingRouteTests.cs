using System.Web.Routing;
using NUnit.Framework;

namespace TestsRelevantToMvc5OnMono
{
    [TestFixture]
    public class SystemWebRoutingRouteTests
    {
        [Test]
        public void Should_have_RouteExistingFiles_property_which_defaults_to_true()
        {
            var route = new Route("foo", null);
            Assert.IsTrue(route.RouteExistingFiles);
            route.RouteExistingFiles = false;
            Assert.IsFalse(route.RouteExistingFiles);
        }
    }
}
