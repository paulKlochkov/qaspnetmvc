using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Configuration;
using System.Data.SqlClient;
using Qulix.Data.Connectivity;

namespace Qulix.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            ConnectionPool.Instance.SetConnectionString(connectionString);
            var connection = ConnectionPool.Instance.GetConnection();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
