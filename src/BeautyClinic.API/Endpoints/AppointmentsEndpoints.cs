using BeautyClinic.API.Features.Appointments.GetAppointments;
using BeautyClinic.API.Features.Appointments.SaveAppointment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeautyClinic.API.Endpoints;

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
            //.Accepts<GetAppointmentsQuery>(ContentType)
            .Produces<ApiResponse<List<AppointmentDto>>>(200)
            .WithTags(Tag);

        app.MapPost($"${BaseRoute}/SaveAppointment", SaveAppointment)
            .WithName("SaveAppointment")
            .Accepts<SaveAppointmentCommand>(ContentType)
            .Produces<ApiResponse<SaveAppointmentResponseDto>>(200)
            .WithTags(Tag);
    }

    private static async Task<IResult> GetAppointments([FromBody] GetAppointmentsRequestDto request)
    {
        //var query = new GetAppointmentsQuery
        //{
        //    ProviderId = request.ProviderId,
        //    ServiceIds = request.ServiceIds,
        //    Year = request.Year,
        //    Month = request.Month,
        //    Day = request.Day
        //};
        //var response = await mediator.Send(query);
        return Results.Ok();
    }

    private static async Task<IResult> SaveAppointment([FromBody] GetProviderServicesRequestDto request)
    {
        //var response = await mediator.Send(command);
        //return Results.Ok(response);
        return Results.Ok();
    }
}
