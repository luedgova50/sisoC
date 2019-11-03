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

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Civil> Civils { get; set; }

        public DbSet<FactorRh> FactorRhs { get; set; }

        public DbSet<SchoolLevel> SchoolLevels { get; set; }

        public DbSet<Profession> Professions { get; set; }

        public DbSet<DriveLicense> DriveLicenses { get; set; }

        public DbSet<Epsa> Epsas { get; set; }

        public DbSet<Arpr> Arprs { get; set; }

        public DbSet<Afpe> Afpes { get; set; }
    }
}