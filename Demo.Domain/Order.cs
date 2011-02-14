using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Domain
{
    public class Order : EntityBase
    {
        public virtual Customer Customer { get; set; }
        public virtual IList<ProductInOrder> Products { get; set; }

        public virtual decimal Total
        {
            get { return Products.Sum(x => x.Product.Price * x.Quantity); }
        }
    }
}