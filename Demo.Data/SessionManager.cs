﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

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
                    .Mappings(x => x
                                       .FluentMappings.AddFromAssemblyOf<SessionManager>()
                                       .Conventions.AddFromAssemblyOf<SessionManager>())
                    // This line tells nhibernate to store the session in the HttpContext object of each web request
                    .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "managed_web"))
                    .ExposeConfiguration(c => { configuration = c; })
                    .BuildSessionFactory();

            _configuration = configuration;
        }
    }
}
