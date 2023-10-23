using cindia_back.Models.Dto;

namespace cindia_back.Repository;

public interface IDemandeRepository
{
    Task<IEnumerable<DemandeDto>> GetDemandes();
    Task<DemandeDto> GetDemandeById(int DemandeId);
    Task<DemandeDto> CreateUpdateDemande(DemandeDto demandeDto);
    Task<bool> DeleteDemande(int DemandeId);
    Task<bool> UpdateStatus(int DemandeId);




}