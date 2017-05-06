

namespace AdventureWork.Data.Context
{
    using AdventureWork.Domain.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class AdventureWorksEntities : DbContext
    {
        public AdventureWorksEntities()
            : base("name=AdventureWorksEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<ProductDescription> ProductDescriptions { get; set; }
    }
}
