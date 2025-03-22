namespace BeautyClinic.API.Models;

public class ClinicProvider
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } 
    public bool IsActive { get; set; } 
    public DateTime CreatedOn { get; set; } 
}
