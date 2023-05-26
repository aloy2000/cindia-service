
using cindia_back.Models.Dto;

namespace cindia_back.Repository;

public interface ICasierRepository
{
  Task<CasierDto> GetCasiers();
  Task<CasierDto> GetCasiersById(int CasierId); 
  Task<CasierDto> UpdateCasier( CasierDto casierDto);
  Task<bool> DeleteCasier(int CasierId);


}