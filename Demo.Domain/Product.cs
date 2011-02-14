using System;
using System.Linq;
using System.Text;

namespace Demo.Domain
{
    public class Product : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
    }
}
