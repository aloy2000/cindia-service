using AutoMapper;
using cindia_back.DbContext;
using cindia_back.Models;
using cindia_back.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace cindia_back.Repository;

public class DistrictRepository: IDistrictRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
   
    //constructon
    public DistrictRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public async Task<IEnumerable<DistrictDto>> GetDistrict()
    {
        var districts = await _db.Districts.ToListAsync();
        return _mapper.Map<List<DistrictDto>>(districts);
    }

    public async  Task<DistrictDto> GetDistrictById(int districtId)
    {
        var district = await _db.Districts.Where(section => section.DistrictId == districtId).FirstOrDefaultAsync();
        return _mapper.Map<DistrictDto>(district);
    }

    public Task<DistrictDto> UpdateDistrcit(DistrictDto districtDto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteDistrict(int districtId)
    {
        try
        {
            var districtToDelete = await _db.Districts.FirstOrDefaultAsync(district => district.DistrictId == districtId);
            if (districtToDelete is null)
            {
                return false;
            }

            _db.Districts.Remove(districtToDelete);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<DistrictDto> CreateDistrict(DistrictDto districtDto)
    {
        District district = _mapper.Map<DistrictDto, District>(districtDto);
        _db.Districts.Add(district);
        await _db.SaveChangesAsync();
        return _mapper.Map<District, DistrictDto>(district);
    }
}