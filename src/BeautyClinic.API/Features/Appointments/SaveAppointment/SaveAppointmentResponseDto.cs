namespace BeautyClinic.API.Features.Appointments.SaveAppointment;

public class SaveAppointmentResponseDto
{
    public int Id { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public int StartHour { get; set; }
    public int StartMinute { get; set; }
    public int EndHour { get; set; }
    public int EndMinute { get; set; }
    public int TimeSpanMinute { get; set; }
    public int ProviderId { get; set; }
    public int ServiceId { get; set; }
    public int? CustomerId { get; set; }
    public AppointmentStatus Status { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Mobile { get; set; }
    public string? Code { get; set; }
}