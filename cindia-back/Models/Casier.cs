using System.ComponentModel.DataAnnotations;

namespace cindia_back.Models;


public class Casier
{
    [Key] public int CasierId { get; set; }

    [Required]public string? DateInculpation{ get; set; }

    [Required]public string? DateDelie { get; set; }

    [Required]public string? Peine { get; set; }

    [Required]public string? DateAudiance { get; set; }
    
    // public  ICollection<User> CasierUser { get; set; }
    public int CasierUserId { get; set; }
    public User UserCasier { get; set; }


    
}