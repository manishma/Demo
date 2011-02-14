using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace B2BProductCatalog.Data.NHibernateMaps.Conventions
{
    public class HasManyToManyConvention : IHasManyToManyConvention
    {
        public void Apply(IManyToManyCollectionInstance instance)
        {
            instance.Cascade.SaveUpdate();
        }
    }
}
