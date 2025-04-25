
using BeautyClinic.API.Common.Endpoints.Enums;

namespace BeautyClinic.API.Features.Appointments.SaveAppointment;

public class SaveAppointmentHandler : IRequestHandler<SaveAppointmentCommand, ApiResponse<SaveAppointmentResponseDto>>
{
    private readonly BeautyClinicDbContext _dbContext;

    public SaveAppointmentHandler(BeautyClinicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ApiResponse<SaveAppointmentResponseDto>> Handle(SaveAppointmentCommand request, CancellationToken cancellationToken)
    {
        var date = new DateTime(request.Year, request.Month, request.Day);
        var existingAppointment = await _dbContext.Appointments
            .AnyAsync(a => a.ProviderId == request.ProviderId &&
                           a.Date.Date == date.Date &&
                           a.StartHour == request.StartHour &&
                           a.StartMinute == request.StartMinute &&
                           a.Status == AppointmentStatus.Reserved, cancellationToken);
        if (existingAppointment)
            throw new InvalidOperationException("This time slot is already booked.");

        if (!await _dbContext.Providers.AnyAsync(p => p.Id == request.ProviderId, cancellationToken))
            throw new Exception("Provider not found");
        if (request.ServiceIds.Any() && !_dbContext.Services
            .Where(s => request.ServiceIds.Contains(s.Id))
            .CountAsync(cancellationToken)
            .Equals(request.ServiceIds.Count))
            throw new Exception("One or more services not found");

        int? customerId = request.CustomerId;
        if (customerId == 0 || customerId == null)
        {
            var customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Mobile = request.Mobile,
                Code = request.Code
            };
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync(cancellationToken);
            customerId = customer.Id;
        }

        var appointment = new Appointment
        {
            ProviderId = request.ProviderId,
            Date = date,
            StartHour = request.StartHour,
            StartMinute = request.StartMinute,
            EndHour = request.EndHour,
            EndMinute = request.EndMinute,
            TimeSpanMinute = request.TimeSpanMinute,
            Status = request.Status,
            CustomerId = customerId,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Mobile = request.Mobile,
            Code = request.Code,
            AppointmentServices = request.ServiceIds.Select(sid => new AppointmentService
            {
                ServiceId = sid
            }).ToList()
        };

        _dbContext.Appointments.Add(appointment);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var responseDto = new SaveAppointmentResponseDto
        {
            Id = appointment.Id,
            Year = request.Year,
            Month = request.Month,
            Day = request.Day,
            StartHour = request.StartHour,
            StartMinute = request.StartMinute,
            EndHour = request.EndHour,
            EndMinute = request.EndMinute,
            TimeSpanMinute = request.TimeSpanMinute,
            ProviderId = request.ProviderId,
            ServiceId = request.ServiceIds.FirstOrDefault(),
            CustomerId = customerId,
            Status = request.Status,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Mobile = request.Mobile,
            Code = request.Code
        };

        return new ApiResponse<SaveAppointmentResponseDto>
        {
            Succeeded = true,
            Message = "با موفقیت ثبت شد",
            Data = responseDto
        };
    }
}