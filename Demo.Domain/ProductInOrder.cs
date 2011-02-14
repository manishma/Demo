using System;

namespace Demo.Domain
{
    public class ProductInOrder : EntityBase
    {
        public virtual Product Product { get; set; }
        public virtual int Quantity { get; set; }

        public virtual decimal Total
        {
            get { return Product.Price*Quantity; }
        }
    }
}