namespace cindia_back.Models.Dto;

public class SectionDto
{
     public int SectionId { get; set; }
     public string? SectionName { get; set; }
    public virtual ICollection<User> Users { get; set; }
    public virtual  ICollection<District> SectionDistricts { get; set; }
}