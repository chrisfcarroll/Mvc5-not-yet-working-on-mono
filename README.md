Mvc5-not-yet-working-on-mono
============================

Modified MVC 5 template to show what does/doesn't yet work

# Building and partially running Asp.Net MVC5 on Mono

#### \
This template is created from the Visual Studion 2012 template

Which I then updated via NuGet (in Visual Studio still) which updated it to MVC 5.

#### The conversion from MVC 4 to MVC 5 is described at:

http://www.asp.net/mvc/tutorials/mvc-5/how-to-upgrade-an-aspnet-mvc-4-and-web-api-project-to-aspnet-mvc-5-and-web-api-2\
Except: I skipped step 2, upgrading to WebApi 2 because that doesn't work yet.

#### The changes made to run it on mono are similar to those described at

http://www.cafe-encounter.net/p1510/asp-net-mvc4-net-framework-version-4-5-c-razor-template-for-mono-on-mac-and-linux\
Except that removing EntityFramework now seems unnecessary.

#### That gets you to this project which runs MVC5

Except:\
     

#### What doesn't yet work on MVC 5

The HtmlHelper : if you unescape this, @@[@Html.ActionLink]("Home", "Index", "Home") it will error with this stack trace:\
       

### System.MissingMethodException

Method not found: 'System.Web.Routing.RouteCollection.get\_AppendTrailingSlash'.

Description: HTTP 500.Error processing request.

Details: Non-web exception. Exception origin (name of application or object): System.Web.Mvc.

\<pre\>\
 System.MissingMethodException\

Method not found: 'System.Web.Routing.RouteCollection.get\_AppendTrailingSlash'.\
 \
 Description: HTTP 500.Error processing request.\

Details: Non-web exception. Exception origin (name of application or object): System.Web.Mvc.\
 Exception stack trace:\

  at System.Web.Mvc.RouteCollectionExtensions.GetVirtualPathForArea (System.Web.Routing.RouteCollection routes, System.Web.Routing.RequestContext requestContext, System.String name, System.Web.Routing.RouteValueDictionary values, System.Boolean& usingAreas) [0x00000] in \<filename unknown\>:0 \

  at System.Web.Mvc.RouteCollectionExtensions.GetVirtualPathForArea (System.Web.Routing.RouteCollection routes, System.Web.Routing.RequestContext requestContext, System.String name, System.Web.Routing.RouteValueDictionary values) [0x00000] in \<filename unknown\>:0 \

  at System.Web.Mvc.UrlHelper.GenerateUrl (System.String routeName, System.String actionName, System.String controllerName, System.Web.Routing.RouteValueDictionary routeValues, System.Web.Routing.RouteCollection routeCollection, System.Web.Routing.RequestContext requestContext, Boolean includeImplicitMvcValues) [0x00000] in \<filename unknown\>:0 \

  at System.Web.Mvc.UrlHelper.GenerateUrl (System.String routeName, System.String actionName, System.String controllerName, System.String protocol, System.String hostName, System.String fragment, System.Web.Routing.RouteValueDictionary routeValues, System.Web.Routing.RouteCollection routeCollection, System.Web.Routing.RequestContext requestContext, Boolean includeImplicitMvcValues) [0x00000] in \<filename unknown\>:0 \

  at System.Web.Mvc.HtmlHelper.GenerateLinkInternal (System.Web.Routing.RequestContext requestContext, System.Web.Routing.RouteCollection routeCollection, System.String linkText, System.String routeName, System.String actionName, System.String controllerName, System.String protocol, System.String hostName, System.String fragment, System.Web.Routing.RouteValueDictionary routeValues, IDictionary\`2 htmlAttributes, Boolean includeImplicitMvcValues) [0x00000] in \<filename unknown\>:0 \

  at System.Web.Mvc.HtmlHelper.GenerateLink (System.Web.Routing.RequestContext requestContext, System.Web.Routing.RouteCollection routeCollection, System.String linkText, System.String routeName, System.String actionName, System.String controllerName, System.String protocol, System.String hostName, System.String fragment, System.Web.Routing.RouteValueDictionary routeValues, IDictionary\`2 htmlAttributes) [0x00000] in \<filename unknown\>:0 \

  at System.Web.Mvc.HtmlHelper.GenerateLink (System.Web.Routing.RequestContext requestContext, System.Web.Routing.RouteCollection routeCollection, System.String linkText, System.String routeName, System.String actionName, System.String controllerName, System.Web.Routing.RouteValueDictionary routeValues, IDictionary\`2 htmlAttributes) [0x00000] in \<filename unknown\>:0 \

  at System.Web.Mvc.Html.LinkExtensions.ActionLink (System.Web.Mvc.HtmlHelper htmlHelper, System.String linkText, System.String actionName, System.String controllerName, System.Web.Routing.RouteValueDictionary routeValues, IDictionary\`2 htmlAttributes) [0x00000] in \<filename unknown\>:0 \

  at System.Web.Mvc.Html.LinkExtensions.ActionLink (System.Web.Mvc.HtmlHelper htmlHelper, System.String linkText, System.String actionName, System.String controllerName) [0x00000] in \<filename unknown\>:0 \

  at ASP.\_Page\_Views\_Home\_Index\_cshtml.Execute () [0x000cd] in /Users/carrolls/Desktop/Software/dotNet/VSTemplates/Mvc5CSharpRazorFx45Intranet/Mvc5CSharpRazorFx45Intranet/Views/Home/Index.cshtml:24 \

  at System.Web.WebPages.WebPageBase.ExecutePageHierarchy () [0x00000] in \<filename unknown\>:0 \

  at System.Web.Mvc.WebViewPage.ExecutePageHierarchy () [0x00000] in \<filename unknown\>:0 \

  at System.Web.WebPages.StartPage.RunPage () [0x00000] in \<filename unknown\>:0 \

  at System.Web.WebPages.StartPage.ExecutePageHierarchy () [0x00000] in \<filename unknown\>:0 \

  at System.Web.WebPages.WebPageBase.ExecutePageHierarchy (System.Web.WebPages.WebPageContext pageContext, System.IO.TextWriter writer, System.Web.WebPages.WebPageRenderingBase startPage) [0x00000] in \<filename unknown\>:0 \

  at System.Web.Mvc.RazorView.RenderView (System.Web.Mvc.ViewContext viewContext, System.IO.TextWriter writer, System.Object instance) [0x00000] in \<filename unknown\>:0 \

  at System.Web.Mvc.BuildManagerCompiledView.Render (System.Web.Mvc.ViewContext viewContext, System.IO.TextWriter writer) [0x00000] in \<filename unknown\>:0 \

  at System.Web.Mvc.ViewResultBase.ExecuteResult (System.Web.Mvc.ControllerContext context) [0x00000] in \<filename unknown\>:0 \

  at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult (System.Web.Mvc.ControllerContext controllerContext, System.Web.Mvc.ActionResult actionResult) [0x00000] in \<filename unknown\>:0 \

  at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive (IList\`1 filters, Int32 filterIndex, System.Web.Mvc.ResultExecutingContext preContext, System.Web.Mvc.ControllerContext controllerContext, System.Web.Mvc.ActionResult actionResult) [0x00000] in \<filename unknown\>:0 \

  at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive (IList\`1 filters, Int32 filterIndex, System.Web.Mvc.ResultExecutingContext preContext, System.Web.Mvc.ControllerContext controllerContext, System.Web.Mvc.ActionResult actionResult) [0x00000] in \<filename unknown\>:0     \
 \</pre\>