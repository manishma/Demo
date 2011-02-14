using FluentNHibernate.Conventions;
using FluentNHibernate.Mapping;

namespace B2BProductCatalog.Data.NHibernateMaps.Conventions
{
    public class HasManyConvention : IHasManyConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IOneToManyCollectionInstance instance)
        {
            instance.Key.Column(instance.EntityType.Name + "Id");
            instance.Key.ForeignKey("Fk_"+ instance.ChildType.Name + "_" + instance.EntityType.Name);
        }
    }
}
