using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Configuration = NHibernate.Cfg.Configuration;

namespace Demo.Data
{
    public class SessionManager
    {
        private readonly static SessionManager Instance = new SessionManager();

        private readonly ISessionFactory _sessionFactory;
        private readonly Configuration _configuration;

        public static ISessionFactory SessionFactory
        {
            get { return Instance._sessionFactory; }
        }

        public static Configuration Configuration
        {
            get { return Instance._configuration; }
        }


        public static ISession OpenSession()
        {
            return Instance._sessionFactory.OpenSession();
        }

        public static ISession CurrentSession
        {
            get { return Instance._sessionFactory.GetCurrentSession(); }
        }

        private SessionManager()
        {
            Configuration configuration = null;

            _sessionFactory =
                Fluently.Configure()
                    .Database(
                        MsSqlCeConfiguration.Standard.ConnectionString(s => s.FromConnectionStringWithKey("DemoDB")))
                    .Mappings(x =>
                                  {
                                      if (false)
                                      {
                                          var fm = x.FluentMappings;

                                          fm
                                              .AddFromAssemblyOf<SessionManager>()
                                              .Conventions.AddFromAssemblyOf<SessionManager>();

                                          var dir = ConfigurationManager.AppSettings["xmlMappingOutputDirectory"];

                                          if (!String.IsNullOrEmpty(dir))
                                              fm.ExportTo(dir);
                                      }
                                      else
                                      {
                                          x.HbmMappings.AddFromAssemblyOf<SessionManager>();

                                      }
                                  })
                    // This line tells nhibernate to store the session in the HttpContext object of each web request
                    .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "managed_web"))
                    .ExposeConfiguration(c => { configuration = c; })
                    .BuildSessionFactory();

            _configuration = configuration;
        }
    }
}
