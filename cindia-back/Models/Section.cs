//fokotany
using System.ComponentModel.DataAnnotations;

namespace cindia_back.Models;

public class Section
{
    [Key] public int SectionId { get; set; }
    [Required] public string? SectionName { get; set; }
    public virtual ICollection<User> Users { get; set; }
    public virtual  ICollection<District> SectionDistricts { get; set; }

}