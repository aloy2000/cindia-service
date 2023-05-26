namespace cindia_back.Models.Dto;

public class DistrictDto
{
    public int DistrictId { get; set; } 
    public string? DistrictName { get; set; }
    
    public  virtual  ICollection<User> DistrictUsers { get; set; }
    public virtual  Section DistrictSection { get; set; }
}