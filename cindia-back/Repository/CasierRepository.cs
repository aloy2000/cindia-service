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
   
    //constructor
    public CasierRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    
    public async Task<IEnumerable<CasierDto>> GetCasiers()
    {
        List<Casier> casiers = await _db.Casiers.ToListAsync();
        return _mapper.Map<List<CasierDto>>(casiers);
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

    public async Task<CasierDto> CreateUpdateCasier(CasierDto casierDto)
    {
        Casier casier = _mapper.Map<CasierDto, Casier>(casierDto);
            if (casier.CasierId > 0)
            {
                _db.Casiers.Update(casier);
            }
            else
            {
                _db.Casiers.Add(casier);
            }

            await _db.SaveChangesAsync();
            return _mapper.Map<Casier, CasierDto>(casier);
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