using Demo.Domain;

namespace Demo.Data.Mapping
{
    public class ProductInOrderMap : EntityMap<ProductInOrder>
    {
        public ProductInOrderMap()
        {
            Map(x => x.Quantity);
            References(x => x.Product);
        }
    }
}