﻿using FluentNHibernate.Conventions;
using FluentNHibernate.Mapping;

namespace B2BProductCatalog.Data.NHibernateMaps.Conventions
{
    public class PrimaryKeyConvention : IIdConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IIdentityInstance instance)
        {
            instance.Column("Id");
            instance.UnsavedValue("0");
            //instance.GeneratedBy.Identity();
            //instance.GeneratedBy.HiLo("1000");
        }
    }
}
