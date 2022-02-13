using Orders_WPF.Models.Configurations;
using Orders_WPF.Models.Domains;
using System;
using System.Data.Entity;
using System.Linq;

namespace Orders_WPF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public DbSet<Claim> Claims { get; set; }

        public DbSet<TypeOfTask> TypeOfTasks { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClaimConfiguration());

            modelBuilder.Configurations.Add(new TypeOfTaskConfiguration());
        }






    }


}