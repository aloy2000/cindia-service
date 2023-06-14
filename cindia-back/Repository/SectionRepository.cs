using AutoMapper;
using cindia_back.DbContext;
using cindia_back.Models;
using cindia_back.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace cindia_back.Repository;

public class SectionRepository : ISectionRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public SectionRepository(ApplicationDbContext db, IMapper mapper)
    {
        db = _db;
        mapper = _mapper;
    }
    public async Task<IEnumerable<SectionDto>> GetSection()
    {
        List<Section> sections = await _db.Sections.ToListAsync();
        return _mapper.Map<List<SectionDto>>(sections);
    }

    public Task<SectionDto> GetSectionById(int SectionId)
    {
        throw new NotImplementedException();
    }

    public Task<SectionDto> UpdateSection(SectionDto SectionDto)
    {
        throw new NotImplementedException();
    }
    
    public async Task<SectionDto> GetSectionsById(int sectionId)
    {
        var section = await _db.Sections.Where(section => section.SectionId == sectionId).FirstOrDefaultAsync();
        return _mapper.Map<SectionDto>(section);
    }
    
    public async Task<object?> CreateUpdateSection(SectionDto sectionDto)
    {
        Section section = _mapper.Map<SectionDto, Section>(sectionDto);
        if (section.SectionId > 0)
        {
            _db.Sections.Update(section);
        }
        else
        {
            _db.Sections.Add(section);
        }

        await _db.SaveChangesAsync();
        return _mapper.Map<Section, SectionDto>(section);
    }

    public async Task<bool> DeleteSection(int SectionId)
    {
        try
        {
            var sectiontodelete = await _db.Sections.FirstOrDefaultAsync(section => section.SectionId == SectionId);
            if (sectiontodelete is null)
            {
                return false;
            }

            _db.Sections.Remove(sectiontodelete);
            await _db.SaveChangesAsync();
            return true;
        }
        catch(Exception e)
        {
            return false;
        }
    }
}