using Mongo.Services.ProductAPI.Models;

namespace cindia_back.DbContext;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }
    public DbSet<Product> Products { get; set; } // Add model in database exemple

}