using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace cindia_back.Models;

public class User
{
    [Key] public  int UserId { get; set; }
    
    [Required]public string? Name { get; set; }

    [Required]public string? FirstName { get; set; }

    [Required]public DateTime Birthday { get; set; }

    [Required]public string? Birthplace { get; set; }
    
    [Required]public string? Address { get; set; }

    [Required]public string? FathersName { get; set; }

    [Required]public string? MothersName { get; set; }

    [Required]public string? PlaceOfIssue { get; set; }
    
    [Required]public string? Sex { get; set; }

    [Required]public string? Tel { get; set; }

    [Required]public string? NumCIN { get; set; }
    
    [Required]public string? ScanCIN { get; set; }

    [Required] public string? Password { get; set; }
    
    public int SectionId { get; set; }
    public  Section Section { get; set; }
    
    public int UserCasierId { get; set; }
    public   Casier UserCasier { get; set; }
    
    public int UserDistrictId { get; set; } //foreign key
    public   District UserDistrict { get; set; } // navigation property
    

}