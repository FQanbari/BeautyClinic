using BeautyClinic.API.Features.Appointments.Models;
using BeautyClinic.API.Features.Services.Models;

namespace BeautyClinic.API.Features.Providers.Models;

public class ClinicProvider
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime CreatedOn { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<ProviderService> ProviderServices { get; set; } = new List<ProviderService>();
}
