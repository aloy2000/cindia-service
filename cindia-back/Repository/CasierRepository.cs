using AutoMapper;
using cindia_back.DbContext;
using cindia_back.Models;
using cindia_back.Models.Dto;
using Microsoft.EntityFrameworkCore;




namespace cindia_back.Repository;

public class CasierRepository: ICasierRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
   
    //constructon
    public CasierRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    
    public async Task<CasierDto> GetCasiers()
    {
        List<Casier> casiers = await _db.Casiers.ToListAsync();
        return _mapper.Map<CasierDto>(casiers);
    }

    public Task<CasierDto> GetCasiersById(int CasierId)
    {
        throw new NotImplementedException();
    }

    public async Task<CasierDto> GetCasierById(int casierId)
    {
        var casier = await _db.Casiers.Where(casiers => casiers.CasierId == casierId).FirstOrDefaultAsync();
        return _mapper.Map<CasierDto>(casier);
    }

    public Task<CasierDto> UpdateCasier(CasierDto casierDto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteCasier(int casierId)
    {
        try
        {
            var casiertodelete = await _db.Casiers.FirstOrDefaultAsync(casier => casier.CasierId == casierId);
            if (casiertodelete is null)
            {
                return false;
            }

            _db.Casiers.Remove(casiertodelete);
            await _db.SaveChangesAsync();
            return true;
        }
        catch(Exception e)
        {
            return false;
        }
    }
}