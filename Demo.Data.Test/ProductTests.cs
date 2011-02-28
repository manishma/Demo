using System.Collections.Generic;
using Demo.Domain;
using NUnit.Framework;


namespace Demo.Data.Test
{
    public class ProductTests : RollbackTests
    {
        [Test]
        public void CreateNew()
        {
            var product = new Product
                              {
                                  Name = "Laptop",
                                  Metadata = new Dictionary<string, ProductMetadata>
                                                 {
                                                     {"he", new ProductMetadata
                                                                {
                                                                    Name = "Fuji",
                                                                    Description = "Hi performance laptop",
                                                                }}
                                                 }
                              };

            Session.Save(product);
            Session.Flush();

        }
    }
}
