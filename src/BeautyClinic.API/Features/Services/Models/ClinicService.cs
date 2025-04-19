using BeautyClinic.API.Features.Appointments.Models;

namespace BeautyClinic.API.Features.Services.Models;

public class ClinicService
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedOn { get; set; }

    public ICollection<ProviderService> ProviderServices { get; set; } = new List<ProviderService>();
    public ICollection<AppointmentService> AppointmentServices { get; set; } = new List<AppointmentService>();
}
