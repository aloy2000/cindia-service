
using cindia_back.Models.Dto;

namespace cindia_back.Repository;

public interface ICasierRepository
{
  Task<IEnumerable<CasierDto>> GetCasiers();
  Task<CasierDto> GetCasiersById(int CasierId); 
  Task<CasierDto> CreateUpdateCasier( CasierDto casierDto);
  Task<bool> DeleteCasier(int CasierId);


}