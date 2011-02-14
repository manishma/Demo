using Demo.Domain;

namespace Demo.Data.Mapping
{
    public class OrderMap : EntityMap<Order>
    {
        public OrderMap()
        {
            References(x => x.Customer);
            HasMany(x => x.Products);
        }
    }
}