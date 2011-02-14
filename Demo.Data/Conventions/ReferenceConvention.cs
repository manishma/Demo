using FluentNHibernate.Conventions;
using FluentNHibernate.Mapping;

namespace B2BProductCatalog.Data.NHibernateMaps.Conventions
{
    public class ReferenceConvention : IReferenceConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IManyToOneInstance instance)
        {
            instance.Fetch.Join();
            instance.Column(instance.Property.Name + "Id");
            instance.ForeignKey("Fk_" + instance.EntityType.Name + "_" + instance.Property.Name);
        }
    }
}
