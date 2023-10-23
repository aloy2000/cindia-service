namespace cindia_back.Models.Dto;

public class DemandeDto {
     public int DemandeId { get; set; }
    public DateTime DateDemande { get; set; }

    public string? TypeDemande { get; set; }

    public string? Status { get; set; }

    public int UserId { get; set; }

}