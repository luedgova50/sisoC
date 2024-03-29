﻿namespace sisoC.Models
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

        public DbSet<Pacient> Pacients { get; set; }

        public DbSet<MilitaryService> MilitaryServices { get; set; }

        public DbSet<UserRoles> UserRoles { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<University> Universities { get; set; }

        public DbSet<TypeLogin> TypeLogins { get; set; }

        public DbSet<Enterprise> Enterprises { get; set; }

        public DbSet<ExamenType> ExamenTypes { get; set; }

        public DbSet<ExamenLevel> ExamenLevels { get; set; }

        public DbSet<OtherExam> OtherExams { get; set; }

        public DbSet<ExOpto> ExOptoes { get; set; }

        public DbSet<ExFono> ExFonoes { get; set; }

        public DbSet<ExPsico> ExPsicoes { get; set; }

        public DbSet<ExMedico> ExMedicoes { get; set; }

        public DbSet<ExActivo> ExActivoes { get; set; }

        public DbSet<Examen> Examen { get; set; }

        public DbSet<L250> L250 { get; set; }
    }
}