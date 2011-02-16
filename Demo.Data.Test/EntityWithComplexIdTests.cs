using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Domain;
using NUnit.Framework;

namespace Demo.Data.Test
{
    [TestFixture]
    public class EntityWithComplexIdTests : RollbackTests
    {
        [Test]
        public void Sanity()
        {
            var complexId = new ComplexId
                                {
                                    Id1 = "stringId",
                                    Id2 = Guid.NewGuid(),
                                    Id3 = 25,
                                };

            var entity = new EntityWithComplexId
                             {
                                 Id = complexId,

                                 Property1 = "Property Value 1",
                                 Property2 = "Property Value 2",
                             };
            Session.Save(entity);
            Session.Flush();
            Session.Clear();

            var entity2 = Session.Get<EntityWithComplexId>(complexId);

            Assert.That(entity2, Is.Not.Null);
            Assert.That(entity2.Id, Is.EqualTo(complexId));
        }
    }
}
