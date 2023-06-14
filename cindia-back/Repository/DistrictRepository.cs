using AutoMapper;
using cindia_back.DbContext;
using cindia_back.Models;
using cindia_back.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace cindia_back.Repository;

public class DistrictRepository : IDistrictRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    
    public DistrictRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public async Task<IEnumerable<DistrictDto>> GetDistrict()
    {
        List<District> districts = await _db.Districts.ToListAsync();
        return _mapper.Map<List<DistrictDto>>(districts);
    }
    public Task<DistrictDto> GetDistrictsById(int DistrictId)
    {
        throw new NotImplementedException();
    }
    public async Task<DistrictDto> GetDistrictById(int districtId)
    {
        var district = await _db.Districts.Where(district => district.DistrictId == districtId).FirstOrDefaultAsync();
        return _mapper.Map<DistrictDto>(district);
    }
    public async Task<object?> CreateUpdateDistrict(DistrictDto districtDto)
    {
        District district = _mapper.Map<DistrictDto, District>(districtDto);
        if (district.DistrictId > 0)
        {
            _db.Districts.Update(district);
        }
        else
        {
            _db.Districts.Add(district);
        }

        await _db.SaveChangesAsync();
        return _mapper.Map<District, DistrictDto>(district);
    }
    
    public async Task<bool> DeleteDistrict(int districtId)
    {
        try
        {
            var districttodelete = await _db.Districts.FirstOrDefaultAsync(district => district.DistrictId == districtId);
            if (districttodelete is null)
            {
                return false;
            }

            _db.Districts.Remove(districttodelete);
            await _db.SaveChangesAsync();
            return true;
        }
        catch(Exception e)
        {
            return false;
        }
    }

    

}