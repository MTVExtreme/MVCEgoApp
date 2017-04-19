using PersonalityEgo.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PersonalityEgo.DAL
{
    public class EgoContext : DbContext
    {
        public DbSet<Personality> Personality { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleAssignment> RoleAssignment { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Trial> Trial { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Charge> Charge { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}