using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Qulix.Data.Connectivity;

namespace Qulix.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Init connection pool with connection string from web.config
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            ConnectionPool.Instance.SetConnectionString(connectionString);

            var connection = ConnectionPool.Instance.GetConnection();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
