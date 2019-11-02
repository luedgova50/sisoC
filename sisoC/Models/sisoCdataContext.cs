namespace sisoC.Models
{
    using System.Data.Entity;
    public class SisoCdataContext : DbContext
    {
        public SisoCdataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<sisoC.Models.State> States { get; set; }

        public System.Data.Entity.DbSet<sisoC.Models.City> Cities { get; set; }
    }
}