using Demo.Domain;
using FluentNHibernate.Mapping;

namespace Demo.Data.Mapping
{
    public abstract class EntityMap<TEntity> : ClassMap<TEntity> where TEntity : EntityBase
    {
        protected EntityMap()
        {
            Id(x => x.Id);
        }
    }
}