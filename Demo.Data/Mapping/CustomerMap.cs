using Demo.Domain;

namespace Demo.Data.Mapping
{
    public class CustomerMap : EntityMap<Customer>
    {
        public CustomerMap()
        {
            Map(x => x.FirstName);
            Map(x => x.LastName);

            HasMany(x => x.Orders);
        }
    }
}