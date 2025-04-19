namespace BeautyClinic.API.Features.Appointments.GetAppointments;

public class AppointmentDto
{
    public int StartHour { get; set; }
    public int StartMinute { get; set; }
    public int EndHour { get; set; }
    public int EndMinute { get; set; }
    public int TimeSpanMinute { get; set; }
    public List<int>? Services { get; set; }
    public int ProviderId { get; set; }
    public AppointmentStatus Status { get; set; }
}
