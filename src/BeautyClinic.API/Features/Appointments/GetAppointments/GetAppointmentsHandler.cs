using BeautyClinic.API.Common;

namespace BeautyClinic.API.Features.Appointments.GetAppointments;

public class GetAppointmentsHandler : IRequestHandler<GetAppointmentsQuery, ApiResponse<List<AppointmentDto>>>
{
    private readonly BeautyClinicDbContext _dbContext;

    public GetAppointmentsHandler(BeautyClinicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ApiResponse<List<AppointmentDto>>> Handle(GetAppointmentsQuery request, CancellationToken cancellationToken)
    {
        var date = new DateTime(request.Year, request.Month, request.Day);
        if (!await _dbContext.Providers.AnyAsync(p => p.Id == request.ProviderId, cancellationToken))
            throw new Exception("Provider not found");
        var appointments = await _dbContext.Appointments
        .Where(a => a.ProviderId == request.ProviderId &&
        a.Date.Date == date.Date &&
        (request.ServiceIds.Count == 0 || a.AppointmentServices.Any(asp => request.ServiceIds.Contains(asp.ServiceId))))
        .Select(a => new AppointmentDto
        {
            StartHour = a.StartHour,
            StartMinute = a.StartMinute,
            EndHour = a.EndHour,
            EndMinute = a.EndMinute,
            TimeSpanMinute = a.TimeSpanMinute,
            Services = a.AppointmentServices.Select(asp => asp.ServiceId).ToList(),
            ProviderId = a.ProviderId,
            Status = a.Status
        })
        .ToListAsync(cancellationToken);

        return new ApiResponse<List<AppointmentDto>>
        {
            Succeeded = true,
            Data = appointments
        };
    }
}
