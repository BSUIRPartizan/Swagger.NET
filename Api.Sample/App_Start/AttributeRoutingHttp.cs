using System.Reflection;
using System.Web.Routing;
using AttributeRouting.Web.Http.WebHost;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Api.Sample.App_Start.AttributeRoutingHttp), "Start")]

namespace Api.Sample.App_Start {
    public static class AttributeRoutingHttp {
		public static void RegisterRoutes(RouteCollection routes) {
            
			// See http://github.com/mccalltd/AttributeRouting/wiki for more options.
			// To debug routes locally using the built in ASP.NET development server, go to /routes.axd

			// ASP.NET Web API
            routes.MapHttpAttributeRoutes(config =>
            {
                config.ScanAssembly(Assembly.GetExecutingAssembly());
                config.InheritActionsFromBaseController = true;
                config.AutoGenerateRouteNames = false;
                config.UseLowercaseRoutes = true;
            });

		}

        public static void Start() {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
