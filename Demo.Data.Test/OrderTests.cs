using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Domain;
using NUnit.Framework;

namespace Demo.Data.Test
{
    class OrderTests : RollbackTests
    {
        [Test]
        public void CreateNew()
        {
            var customer = Session.QueryOver<Customer>().Take(1).List().Single();

            var order = new Order
                            {
                                Customer = customer,
                                DeliveryStatus = null,
                            };

            Session.Save(order);
            Session.Flush();

        }

        [Test]
        public void Update()
        {
            var order = Session.QueryOver<Order>().Take(1).List().Single();
            order.DeliveryStatus = OrderDeliveryStatus.Received;

            Session.Update(order);
            Session.Flush();

        }
    }
}
