namespace BeautyClinic.API.Features.Appointments.Models;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public string? Code { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
