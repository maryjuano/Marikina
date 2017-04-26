using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BusinessPermit.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<Users> Users { get; set; }      

        public DbSet<UserRoles> UserRoles { get; set; }

        public DbSet<Fee> Fees { get; set; }

        public DbSet<ApplicationType> ApplicationTypes { get; set; }    

        public DbSet<Audit> Audits { get; set; }
        public DbSet<ZoningClearance> ZoningClearance { get; set; }
        public DbSet<LocationalClearance> LocationalClearance { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<BusinessPermit> BusinessPermits { get; set; }
        public DbSet<BuildingPermit> BuildingPermits { get; set; } 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //one-to-many 
            modelBuilder.Entity<Fee>()
                        .HasRequired<ApplicationType>(s => s.ApplicationType)
                        .WithMany(s => s.Fees)
                        .HasForeignKey(s => s.ApplicationTypeId); 

        }
    }


}