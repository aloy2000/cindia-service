using cindia_back.Models.Dto;

namespace cindia_back.Repository;

public interface ISectionRepository
{
    Task<IEnumerable<SectionDto>> GetSection();
    Task<SectionDto> GetSectionById(int SectionId); 
    Task<SectionDto> UpdateSection( SectionDto SectionDto);
    Task<SectionDto> DeleteSection(int SectionId);
}