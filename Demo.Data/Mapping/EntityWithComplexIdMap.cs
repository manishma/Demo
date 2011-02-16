using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Domain;
using FluentNHibernate.Mapping;

namespace Demo.Data.Mapping
{
    public class EntityWithComplexIdMap : ClassMap<EntityWithComplexId>
    {
        public EntityWithComplexIdMap()
        {
            CompositeId(x => x.Id)
                .KeyProperty(x => x.Id1)
                .KeyProperty(x => x.Id2)
                .KeyProperty(x => x.Id3)
                ;

            Map(x => x.Property1);
            Map(x => x.Property2);
        }
    }

}
