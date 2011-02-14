using System;
using System.Collections.Generic;

namespace Demo.Domain
{
    public class Customer : EntityBase
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public virtual IList<Order> Orders { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}