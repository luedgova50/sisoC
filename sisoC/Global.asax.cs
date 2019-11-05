namespace sisoC
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using sisoC.Helpers;
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

            CheckRolesAndSuperUser();

            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void CheckRolesAndSuperUser()
        {
            UsersHelper.CheckRole("Admin");

            UsersHelper.CheckRole("User");

            UsersHelper.CheckRole("Recepcion");

            UsersHelper.CheckRole("Medico");

            UsersHelper.CheckRole("Optometra");

            UsersHelper.CheckRole("Fono");

            UsersHelper.CheckRole("Psicologo");

            UsersHelper.CheckSuperUser();
        }
    }
}
