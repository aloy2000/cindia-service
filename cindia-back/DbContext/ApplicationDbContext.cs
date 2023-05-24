using cindia_back.Models;

namespace cindia_back.DbContext;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }
    public DbSet<Casier> Casiers { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Section>()
            .HasMany(u => u.Users)
            .WithOne(o => o.Section)
            .HasForeignKey(o => o.Section);
        
        modelBuilder.Entity<Casier>()
            .HasMany(c => c.CasierUser)
            .WithOne(u => u.UserCasier)
            .HasForeignKey(u => u.UserCasier);
        
        modelBuilder.Entity<District>()
            .HasMany(u => u.DistrictUsers)
            .WithOne(d => d.UserDistrict)
            .HasForeignKey(u => u.UserDistrict);
        
        modelBuilder.Entity<Section>()
            .HasMany(d => d.SectionDistricts)
            .WithOne(s => s.DistrictSection)
            .HasForeignKey(s => s.DistrictSection);
        
    }
}