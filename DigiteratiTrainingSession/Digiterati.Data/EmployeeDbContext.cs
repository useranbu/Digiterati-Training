using Digiterati.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiterati.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Employees has one to many relationship with Skillmap
            modelBuilder.Entity<SkillMap>()
                  .HasOne(bc => bc.Employees)
                  .WithMany(b => b.SkillMaps)
                  .HasForeignKey(bc => bc.EmployeeID);
            //Skills has one to many relationship with Skillmap
            modelBuilder.Entity<SkillMap>()
                   .HasOne(bc => bc.Skills)
                   .WithMany(b => b.SkillMaps)
                   .HasForeignKey(bc => bc.SkillId);
            //Employees has one to many relationship with SoftLock
            modelBuilder.Entity<Softlock>()
               .HasOne(bc => bc.Employees)
               .WithMany(b => b.SoftLocks)
               .HasForeignKey(bc => bc.EmployeeId);
        }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<SkillMap> SkillMaps { get; set; }
        public DbSet<Softlock> SoftLocks { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
