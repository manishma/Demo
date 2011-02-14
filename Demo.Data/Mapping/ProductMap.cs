using Demo.Domain;

namespace Demo.Data.Mapping
{
    public class ProductMap : EntityMap<Product>
    {
        public ProductMap()
        {
            Map(x => x.Name);
            Map(x => x.Price);
        }
    }
}
