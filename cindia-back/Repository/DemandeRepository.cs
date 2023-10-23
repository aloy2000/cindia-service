using AutoMapper;
using cindia_back.DbContext;
using cindia_back.Models;
using cindia_back.Models.Dto;
using cindia_back.Repository;
using Microsoft.EntityFrameworkCore;

public class DemandeRepository : IDemandeRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public DemandeRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DemandeDto>> GetDemandes()
    {
        var demandes = await _db.Demande.ToListAsync();
        return _mapper.Map<List<DemandeDto>>(demandes);
    }

    public async Task<DemandeDto> GetDemandeById(int DemandeId)
    {
        var district = await _db.Demande.Where(demande => demande.DemandeId == DemandeId).FirstOrDefaultAsync();
        return _mapper.Map<DemandeDto>(district);
    }

    public async Task<DemandeDto> CreateUpdateDemande(DemandeDto demandeDto)
    {
        demandeDto.DateDemande = DateTime.UtcNow;

        var demande = _mapper.Map<DemandeDto, Demande>(demandeDto);
        _db.Demande.Add(demande);
        await _db.SaveChangesAsync();
        return _mapper.Map<Demande, DemandeDto>(demande);
    }

    public async Task<bool> DeleteDemande(int DemandeId)
    {
        try
        {
            var demandeToDelete = await _db.Demande.FirstOrDefaultAsync(demande => demande.DemandeId == DemandeId);
            if (demandeToDelete is null)
            {
                return false;
            }

            _db.Demande.Remove(demandeToDelete);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public Task<bool> UpdateStatus(int DemandeId)
    {
        throw new NotImplementedException();
    }
}
