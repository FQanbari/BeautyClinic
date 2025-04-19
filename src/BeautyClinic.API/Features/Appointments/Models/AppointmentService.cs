using BeautyClinic.API.Features.Services.Models;

namespace BeautyClinic.API.Features.Appointments.Models;

public class AppointmentService
{
    public int AppointmentId { get; set; }
    public int ServiceId { get; set; }

    public Appointment Appointment { get; set; } = null!;
    public ClinicService ClinicService { get; set; } = null!;
}