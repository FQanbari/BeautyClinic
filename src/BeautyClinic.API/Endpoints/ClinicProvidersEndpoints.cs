using BeautyClinic.API.Features.Providers.GetAllProviders;

namespace BeautyClinic.API.Endpoints;

public class ClinicProviderEndpoints : IEndpoints
{
    private const string BaseRoute = "ClinicProvider";
    private const string ContentType = "application/json";
    private const string Tag = "Clinic Provider";

    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        
    }

    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        //app.MapGet(BaseRoute, GetAllClinicProviderAsync)
        //    .WithName("GetAllClinicProvider")
        //    .Produces<ApiResponse<List<ClinicProviderDto>>>(200)
        //    .WithTags(Tag);

    }

    private static async Task<IResult> GetAllClinicProviderAsync(IMediator mediator, GetAllProvidersQuery query)
    {
        var response = await mediator.Send(query);
        return Results.Ok(response);
    }
}
