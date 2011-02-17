using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Domain
{
    public class Product : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }

        public virtual IDictionary<string, ProductMetadata> Metadata { get; set; }
    }
    
    public class ProductMetadata
    {
        public virtual Product Product { get; set; }
        public virtual string Locale { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }

}
