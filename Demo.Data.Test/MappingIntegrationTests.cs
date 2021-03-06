﻿using System.Collections.Generic;
using System.IO;
using Demo.Domain;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Demo.Data.Test
{
    /// <summary>
    /// Provides a means to verify that the target database is in compliance with all mappings.
    /// Taken from http://ayende.com/Blog/archive/2006/08/09/NHibernateMappingCreatingSanityChecks.aspx.
    /// 
    /// If this is failing, the error will likely inform you that there is a missing table or column
    /// which needs to be added to your database.
    /// </summary>
    [TestFixture]
    [System.ComponentModel.Category("DB Tests")]
    public class MappingIntegrationTests
    {
        [SetUp]
        public virtual void SetUp()
        {
        }

        [TearDown]
        public virtual void TearDown()
        {
        }

        [Test]
        public void ConfirmDatabaseMatchesMappings()
        {
            var allClassMetadata = SessionManager.SessionFactory.GetAllClassMetadata();
            
            using (var session = SessionManager.SessionFactory.OpenSession())
            {
                foreach (var entry in allClassMetadata)
                {
                    session.CreateCriteria(entry.Value.GetMappedClass(EntityMode.Poco))
                        .SetMaxResults(0).List();
                }
            }
        }

        /// <summary>
        /// Generates and outputs the database schema SQL to the console
        /// </summary>
        [Test]
        public void RecreateDataBase()
        {
            using (var session = SessionManager.SessionFactory.OpenSession())
            {
                using (TextWriter stringWriter = new StreamWriter("../../../Gen/DataBase.sql"))
                {
                    new SchemaExport(SessionManager.Configuration).Execute(true, true, false, session.Connection,
                                                                           stringWriter);
                }
            }

            using (var session = SessionManager.SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                // create initial data
                var product = new Product
                {
                    Name = "Laptop",
                    Price = 5000,
                    Metadata = new Dictionary<string, ProductMetadata>
                                                 {
                                                     {"en", new ProductMetadata
                                                                {
                                                                    Name = "Fuji",
                                                                    Description = "Hi performance laptop",
                                                                }}
                                                 }
                };

                session.Save(product);
                session.Flush();


                var customer = new Customer
                                   {
                                       FirstName = "Joe",
                                       LastName = "Smith",
                                       Type = CustomerType.Private,
                                       Orders = new List<Order>(),
                                   };

                session.Save(customer);
                session.Flush();


                var order = new Order
                                {
                                    Customer = customer,
                                    Products = new List<ProductInOrder>
                                                   {
                                                       new ProductInOrder
                                                           {
                                                               Product = product,
                                                               Quantity = 2,
                                                           }
                                                   }
                                };

                session.Save(order);
                session.Flush();

                trans.Commit();
            }
        }

    }
}
