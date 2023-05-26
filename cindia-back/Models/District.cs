using System.ComponentModel.DataAnnotations;

namespace cindia_back.Models;

public class District
{
    [Key] public int DistrictId { get; set; }
    [Required] public string? DistrictName { get; set; }
    
    public    ICollection<User> DistrictUsers { get; set; }
    public virtual ICollection<Section> DistrictSection { get; set; }

}