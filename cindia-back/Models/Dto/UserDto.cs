namespace cindia_back.Models.Dto;

public class UserDto
{
    public  int UserId { get; set; }
    
    public string? Name { get; set; }

    public string? FirstName { get; set; }
    
    public string? Birthday { get; set; }

    public DateTime? Birthplace { get; set; }
    
    public string? Address { get; set; }

    public string? FathersName { get; set; }

    public string? MothersName { get; set; }

    public string? PlaceOfIssue { get; set; }
    
    public string? Sex { get; set; }

    public string? Tel { get; set; }

    public string? NumCIN { get; set; }
    
    public string? ScanCIN { get; set; }
    
    public string? Password { get; set; }
    
    public int SectionId { get; set; }
    public  Section Section { get; set; }
    public int UserCasierId { get; set; }
    public  Casier UserCasier { get; set; }
    public int UserDistrictId { get; set; } //foreign key
    public  District UserDistrict { get; set; }

}