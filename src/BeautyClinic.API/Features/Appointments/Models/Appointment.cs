using BeautyClinic.API.Features.Providers.Models;

namespace BeautyClinic.API.Features.Appointments.Models;

public class Appointment
{
    public int Id { get; set; }
    public int ProviderId { get; set; }
    public DateTime Date { get; set; }
    public int StartHour { get; set; }
    public int StartMinute { get; set; }
    public int EndHour { get; set; }
    public int EndMinute { get; set; }
    public int TimeSpanMinute { get; set; }
    public AppointmentStatus Status { get; set; }
    public int? CustomerId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Mobile { get; set; }
    public string? Code { get; set; }

    public ClinicProvider ClinicProvider { get; set; } = null!;
    public Customer? Customer { get; set; }
    public ICollection<AppointmentService> AppointmentServices { get; set; } = new List<AppointmentService>();
}
