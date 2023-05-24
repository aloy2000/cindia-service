namespace cindia_back.Models.Dto;

public class CasierDto
{
    public int CasierId { get; set; }

    public string? DateInculpation{ get; set; }

    public string? DateDelie { get; set; }

    public string? Peine { get; set; }

    public string? DateAudiance { get; set; }
    
    public virtual ICollection<User> CasierUser { get; set; }

}
