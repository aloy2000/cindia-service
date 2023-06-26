using cindia_back.Models.Dto;

namespace cindia_back.Repository;

public interface IDistrictRepository
{
    Task<IEnumerable<DistrictDto>> GetDistrict();
    Task<DistrictDto> GetDistrictById(int districtId); 
    Task<DistrictDto> UpdateDistrcit( DistrictDto districtDto);
    Task<bool> DeleteDistrict(int districtId);
    Task<DistrictDto> CreateDistrict(DistrictDto districtDto);
}