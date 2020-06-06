using FundMeUp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundMeUp.Repository
{
  public class FundMeUpDbContext : DbContext
  {
        public DbSet<Backer> Backers { get; set; }
        public DbSet<BackerProject> BackerProjects { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCreator> ProjectCreators { get; set; }
        public DbSet<Reward> Rewards { get; set; }

        //εμενα δουλευει μονο τοπικα 
        //public readonly static string ConnectionString =
        //    "Data Source = localhost;" +
        //    "Initial Catalog = fundmeup-db; " +
        //    "Integrated Security = True;";


        public FundMeUpDbContext(DbContextOptions<FundMeUpDbContext> options)
                    : base(options)
        { }

        public FundMeUpDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=192.168.99.100;Database=fundmeup-db;User Id=sa;Password=admin!@#123");
            //optionsBuilder.UseSqlServer("Server=localhost;Database=fundmeup-db;User Id=sa;Password=admin!@#123");

            //optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Backer>()
                        .ToTable("Backer");

            modelBuilder.Entity<BackerProject>()
                        .ToTable("BackerProject");

            modelBuilder.Entity<Project>()
                        .ToTable("Project");

            modelBuilder.Entity<ProjectCreator>()
                        .ToTable("ProjectCreator");

            modelBuilder.Entity<Reward>()
                        .ToTable("Reward");


            // configures Many-to-Many relationship    
            modelBuilder.Entity<BackerProject>()
                        .HasKey(bp => bp.Id);
            modelBuilder.Entity<BackerProject>()
                        .HasOne(bp => bp.Backer)
                        .WithMany(b => b.BackerProject)
                        .HasForeignKey(bp => bp.BackerId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BackerProject>()
                        .HasOne(bp => bp.Project)
                        .WithMany(p => p.BackerProject)
                        .HasForeignKey(bp => bp.ProjectId)
                        .OnDelete(DeleteBehavior.Restrict);

            // configures One-to-Many relationship
            modelBuilder.Entity<BackerProject>()
                        .HasOne<Reward>(s => s.Reward)
                        .WithMany(g => g.BackerProjects)
                        .HasForeignKey(s => s.RewardId)
                        .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
