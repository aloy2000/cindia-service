using cindia_back.Models.Dto;

namespace cindia_back.Repository;

public interface ISectionRepository
{
    Task<IEnumerable<SectionDto>> GetSection();
    Task<SectionDto> GetSectionById(int sectionId); 
    Task<SectionDto> UpdateSection( SectionDto sectionDto);
    Task<bool> DeleteSection(int sectionId);
}