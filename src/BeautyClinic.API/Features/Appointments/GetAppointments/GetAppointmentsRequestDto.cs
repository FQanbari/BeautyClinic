namespace BeautyClinic.API.Features.Appointments.GetAppointments;

public class GetAppointmentsRequestDto
{
    public int ProviderId { get; set; }
    public List<int> ServiceIds { get; set; } = new List<int>();
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
}