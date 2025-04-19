namespace BeautyClinic.API.Features.Appointments.SaveAppointment;

public class SaveAppointmentCommand : IRequest<ApiResponse<SaveAppointmentResponseDto>>
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public int StartHour { get; set; }
    public int StartMinute { get; set; }
    public int EndHour { get; set; }
    public int EndMinute { get; set; }
    public int TimeSpanMinute { get; set; }
    public int ProviderId { get; set; }
    public List<int> ServiceIds { get; set; } = new List<int>();
    public int? CustomerId { get; set; }
    public AppointmentStatus Status { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
}
