using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Studenci { get; set; }
        public DbSet<Grupa> Grupy { get; set; }
        public DbSet<Historia> Historia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definiowanie relacji
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Grupa)
                .WithMany(g => g.Studenci)
                .HasForeignKey(s => s.IDGrupy)
                .OnDelete(DeleteBehavior.SetNull);

            // Procedura składowana do dodawania studenta
            modelBuilder.Entity<Student>().HasKey(s => s.ID);

        }
    }
}