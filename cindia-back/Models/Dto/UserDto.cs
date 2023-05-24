namespace cindia_back.Models.Dto;

public class UserDto
{
    public  int UserId { get; set; }
    
    public string? Name { get; set; }

    public string? FirstName { get; set; }
    
    public string? Birthday { get; set; }

    public string? Birthplace { get; set; }
    
    public string? Adress { get; set; }

    public string? FathersName { get; set; }

    public string? MothersName { get; set; }

    public string? PlaceOfIssue { get; set; }
    
    public string? Sex { get; set; }

    public string? Tel { get; set; }

    public string? NumCIN { get; set; }
    
    public string? ScanCIN { get; set; }
    
    
    public virtual Section Section { get; set; }
    public virtual Casier UserCasier { get; set; }
    public virtual District UserDistrict { get; set; }

}