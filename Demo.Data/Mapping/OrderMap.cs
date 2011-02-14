using Demo.Domain;

namespace Demo.Data.Mapping
{
    public class OrderMap : EntityMap<Order>
    {
        public OrderMap()
        {
            References(x => x.Customer);
            Map(x => x.DeliveryStatus);//.CustomType<OrderDeliveryStatus>();
            HasMany(x => x.Products);
        }
    }
}