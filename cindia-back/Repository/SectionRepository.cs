using AutoMapper;
using cindia_back.DbContext;
using cindia_back.Models;
using cindia_back.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace cindia_back.Repository;

public class SectionRepository: ISectionRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public SectionRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _db = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SectionDto>> GetSection()
    {
        var sections = await _db.Sections.ToListAsync();
        return _mapper.Map<List<SectionDto>>(sections);
    }

    public async Task<SectionDto> GetSectionById(int sectionId)
    {
        var section = await _db.Sections.Where(section => section.SectionId == sectionId).FirstOrDefaultAsync();
        return _mapper.Map<SectionDto>(section);
    }

    public async Task<SectionDto> UpdateSection(SectionDto sectionDto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteSection(int sectionId)
    {
        try
        {
            var sectionToDelete = await _db.Sections.FirstOrDefaultAsync(section => section.DistrictId == sectionId);
            if (sectionToDelete is null)
            {
                return false;
            }

            _db.Sections.Remove(sectionToDelete);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}