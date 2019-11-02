namespace sisoC
{
    
    using System.Data.Entity;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using sisoC.Models;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Database.
                SetInitializer(
                new MigrateDatabaseToLatestVersion<
                    SisoCdataContext, 
                    Migrations.Configuration>());

            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
