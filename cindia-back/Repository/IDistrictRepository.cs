using cindia_back.Models.Dto;

namespace cindia_back.Repository;

public interface IDistrictRepository
{
    Task<IEnumerable<DistrictDto>> GetDistrict();
    Task<DistrictDto> GetDistrictById(int DistrictId); 
    Task<bool> DeleteDistrict(int DistrictId);
   Task<object?> CreateUpdateDistrict(DistrictDto districtDto);
}