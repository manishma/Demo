using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Demo.Data;
using NHibernate.Context;

namespace Demo.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Products", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            //http://gbuchoa2.blogspot.com/2009/10/sql-server-compact-is-not-intended-for.html
            AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);

            // init NHProf
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            
        }


        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var session = SessionManager.SessionFactory.OpenSession();
            session.BeginTransaction();
            ManagedWebSessionContext.Bind(HttpContext.Current, session);
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var session = ManagedWebSessionContext.Unbind(HttpContext.Current, SessionManager.SessionFactory);
            
            if (session != null)
            {
                if (session.Transaction != null)
                {
                    session.Transaction.Commit();
                    session.Transaction.Dispose();
                }

                session.Dispose();
            }

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var session = ManagedWebSessionContext.Unbind(HttpContext.Current, SessionManager.SessionFactory);

            if (session != null)
            {
                if (session.Transaction != null)
                {
                    session.Transaction.Rollback();
                    session.Transaction.Dispose();
                }

                session.Dispose();
            }
        }

    }
}