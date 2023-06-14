using cindia_back.Models.Dto;

namespace cindia_back.Repository;

public interface ISectionRepository
{
    Task<IEnumerable<SectionDto>> GetSection();
    Task<SectionDto> GetSectionById(int SectionId); 
    Task<bool> DeleteSection(int SectionId);
    Task<object?> CreateUpdateSection(SectionDto sectionDto);
}