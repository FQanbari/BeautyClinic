using BeautyClinic.API.Common;
using BeautyClinic.API.Common.Endpoints.Internal;
using BeautyClinic.API.Features.Appointments.GetAppointments;
using BeautyClinic.API.Features.Appointments.SaveAppointment;

namespace BeautyClinic.API.Features.Appointments;

public class AppointmentsEndpoints : IEndpoints
{
    private const string BaseRoute = "v1/Appointments";
    private const string ContentType = "application/json";
    private const string Tag = "Appointment";

    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {

    }

    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost($"${BaseRoute}/GetAppointments", GetAppointments)
            .WithName("GetAppointments")
            //.Accepts<GetAppointmentsRequestDto>(ContentType)
            .Produces<ApiResponse<List<AppointmentDto>>>(200)
            .WithTags(Tag);

        app.MapPost($"${BaseRoute}/SaveAppointment", SaveAppointment)
            .WithName("SaveAppointment")
            //.Accepts<SaveAppointmentRequestDto>(ContentType)
            .Produces<ApiResponse<SaveAppointmentResponseDto>>(200)
            .WithTags(Tag);
    }

    private static async Task<IResult> GetAppointments([FromServices] IMediator mediator, [FromBody] GetAppointmentsRequestDto request)
    {
        var query = new GetAppointmentsQuery
        {
            ProviderId = request.ProviderId,
            ServiceIds = request.ServiceIds,
            Year = request.Year,
            Month = request.Month,
            Day = request.Day
        };
        var response = await mediator.Send(query);
        return Results.Ok(response);
    }

    private static async Task<IResult> SaveAppointment([FromServices] IMediator mediator, [FromBody] SaveAppointmentRequestDto request)
    {
        var command = new SaveAppointmentCommand
        {
            Year = request.Year,
            Month = request.Month,
            Day = request.Day,
            StartHour = request.StartHour,
            StartMinute = request.StartMinute,
            EndHour = request.EndHour,
            EndMinute = request.EndMinute,
            TimeSpanMinute = request.TimeSpanMinute,
            ProviderId = request.ProviderId,
            ServiceIds = request.ServiceIds,
            CustomerId = request.CustomerId,
            Status = request.Status,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Mobile = request.Mobile,
            Code = request.Code
        };
        var response = await mediator.Send(command);
        return Results.Ok(response);
    }
}
