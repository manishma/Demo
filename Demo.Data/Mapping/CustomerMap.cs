using Demo.Domain;

namespace Demo.Data.Mapping
{
    public class CustomerMap : EntityMap<Customer>
    {
        public CustomerMap()
        {
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Type);//.CustomType<CustomerType>().Not.Nullable();

            HasMany(x => x.Orders);
        }
    }
}