using cindia_back.DbContext;
using cindia_back.Models;
using Faker;

namespace cindia_back.utils;

public class DataSeeder
{
    private readonly ApplicationDbContext _dbContext;

    public DataSeeder(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async void SeedData()
    {
        var district = new District() { DistrictName = Lorem.Words(10).ToString()};
        _dbContext.Districts.AddRange(district);
        await _dbContext.SaveChangesAsync();
    }
}