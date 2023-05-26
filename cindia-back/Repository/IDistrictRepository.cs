using cindia_back.Models.Dto;

namespace cindia_back.Repository;

public interface IDistrictRepository
{
    Task<IEnumerable<DistrictDto>> GetDistrict();
    Task<DistrictDto> GetDistrictById(int DistrictId); 
    Task<DistrictDto> UpdateDistrcit( DistrictDto DistrictDto);
    Task<DistrictDto> DeleteDistrict(int DistrictId);
}