using System.Web.Routing;
using NUnit.Framework;

namespace TestsRelevantToMvc5OnMono
{
    [TestFixture]
    public class SystemWebRoutingRouteTests
    {
    
#if NET_4_5
        [Test]
        public void Should_have_RouteExistingFiles_property_which_defaults_to_true()
        {
            var expectedProperty = typeof(Route).GetProperty("RouteExistingFiles");
            Assert.IsNotNull(expectedProperty);
        }
#endif
    }
}
