public class MvcApplication : System.Web.HttpApplication {
2 public static void RegisterRoutes(RouteCollection routes) {
3 routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
4 routes.MapRoute(
5 "Default", // Route name
6 "{controller}/{action}/{id}", // URL with parameters
7 new { controller = "Home",
8 action = "Index",
9 id = UrlParameter.Optional } // Parameter defaults
10 );
11 }
12 protected void Application_Start() {
13 AreaRegistration.RegisterAllAreas();
14 RegisterRoutes(RouteTable.Routes);
15 }
16 }