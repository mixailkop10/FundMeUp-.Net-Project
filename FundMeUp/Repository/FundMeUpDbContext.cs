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
    public DbSet<Project> Projects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);

      optionsBuilder.UseSqlServer("Server=localhost;Database=fundmeup-db;User Id=sa;Password=admin!@#123");
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

    }
  }
}
