using Demo.Domain;
using FluentNHibernate.Mapping;

namespace Demo.Data.Mapping
{
    public class ProductMap : EntityMap<Product>
    {
        public ProductMap()
        {
            Map(x => x.Name);
            Map(x => x.Price);


            HasMany(x => x.Metadata)
                .KeyColumn("ProductId") // todo: use conventions
                .Table("ProductMetadata") // todo: use conventions
                .ForeignKeyConstraintName("Fk_ProductMetadata_Product") // todo: use conventions
                .AsMap(p => p.Locale)
                .Component(
                    x =>
                        {
                            x.Map(m => m.Name);
                            x.Map(m => m.Description);
                        });
        }
    }
}
