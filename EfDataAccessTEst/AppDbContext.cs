using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace EfDataAccessTEst;

public class AppDbContext : DbContext
{
    public DbSet<Animal> Animals { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Animal>().ToCollection("animalsEF");
        modelBuilder.Entity<Animal>().HasKey(x => x.Id);
    }
}