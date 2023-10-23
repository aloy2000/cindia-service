using System.ComponentModel.DataAnnotations;

namespace cindia_back.Models;

public class Demande
{
    [Key] public int DemandeId { get; set; }
    [Required] public DateTime DateDemande { get; set; }

    [Required] public string? TypeDemande { get; set; }

    [Required] public string? Status { get; set; }

    [Required] public int UserId { get; set; }

    [Required] public User UserDemande { get; set; }


}

