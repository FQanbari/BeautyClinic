using BeautyClinic.API.Features.Services.GetAllProviderServices;

namespace BeautyClinic.API.Endpoints;

public class ClinicServicesEndpoints : IEndpoints
{
    private const string BaseRoute = "ClinicService";
    private const string ContentType = "application/json";
    private const string Tag = "Clinic Service";

    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        
    }

    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost(BaseRoute, GetAllProviderServices)
            .WithName("GetAllProviderServices")
            .Accepts<GetAllProviderServicesQuery>(ContentType)
            .Produces<ApiResponse<List<ProviderServiceDto>>>(200)
            .WithTags(Tag);

    }

    private static async Task<IResult> GetAllProviderServices([FromServices] IMediator mediator, [FromBody] GetAllProviderServicesQuery query)
    {
        var response = await mediator.Send(query);
        return Results.Ok(response);
    }
}
