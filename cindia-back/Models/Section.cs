//fokotany
using System.ComponentModel.DataAnnotations;

namespace cindia_back.Models;

public class Section
{
    [Key] public int SectionId { get; set; }
    [Required] public string? SectionName { get; set; }
    public virtual ICollection<User> Users { get; set; }
    public int DistrictId { get; set; }

    public District SectionDistrict { get; set; }
    public User SectionUser { get; set; }

}