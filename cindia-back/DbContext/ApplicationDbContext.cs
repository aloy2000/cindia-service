using cindia_back.Models;

namespace cindia_back.DbContext;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
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
            .HasForeignKey(o => o.SectionId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.UserCasier)
            .WithOne(c => c.UserCasier)
            .HasForeignKey(c => c.CasierUserId);

        modelBuilder.Entity<District>()
            .HasMany(u => u.DistrictUsers)
            .WithOne(d => d.UserDistrict)
            .HasForeignKey(u => u.UserDistrictId);

        modelBuilder.Entity<District>()
            .HasMany(s => s.DistrictSection)
            .WithOne(s => s.SectionDistrict)
            .HasForeignKey(s => s.SectionId);
    }
}