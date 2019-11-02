namespace sisoC.Models
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class SisoCdataContext : DbContext
    {
        public SisoCdataContext() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.
                Conventions.
                Remove<
                    OneToManyCascadeDeleteConvention>();
        }


        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

        public System.Data.Entity.DbSet<sisoC.Models.DocumentType> DocumentTypes { get; set; }
    }
}