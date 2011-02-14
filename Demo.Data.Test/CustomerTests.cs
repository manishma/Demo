using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Domain;
using NUnit.Framework;

namespace Demo.Data.Test
{
    public class CustomerTests: RollbackTests
    {

        [Test]
        public void CreateNew()
        {
            var customer = new Customer
                               {
                                   FirstName = "Test",
                                   LastName = "User",
                                   Type = CustomerType.Private,
                               };

            Session.Save(customer);
            Session.Flush();

        }
    }
}
