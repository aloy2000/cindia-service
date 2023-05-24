using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace cindia_back.Models;

public class User
{
    [Key] public  int UserId { get; set; }
    
    [Required]public string? Name { get; set; }

    [Required]public string? FirstName { get; set; }

    [Required]public string? Birthday { get; set; }

    [Required]public string? Birthplace { get; set; }
    
    [Required]public string? Adress { get; set; }

    [Required]public string? FathersName { get; set; }

    [Required]public string? MothersName { get; set; }

    [Required]public string? PlaceOfIssue { get; set; }
    
    [Required]public string? Sex { get; set; }

    [Required]public string? Tel { get; set; }

    [Required]public string? NumCIN { get; set; }
    
    [Required]public string? ScanCIN { get; set; }
    
    
    public virtual Section Section { get; set; }
    public  virtual Casier UserCasier { get; set; }
    
    public  virtual District UserDistrict { get; set; }

    

}