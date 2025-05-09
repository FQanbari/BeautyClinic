﻿using BeautyClinic.API.Common;
using BeautyClinic.API.Common.Endpoints.Internal;
using BeautyClinic.API.Features.Providers.GetAllProviders;

namespace BeautyClinic.API.Features.ClinicProviders;

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
        app.MapGet(BaseRoute, GetAllClinicProviderAsync)
            .WithName("GetAllClinicProvider")
            .Produces<ApiResponse<List<ClinicProviderDto>>>(200)
            .WithTags(Tag);

    }

    private static async Task<IResult> GetAllClinicProviderAsync([FromServices] IMediator mediator)
    {
        var response = await mediator.Send(new GetAllProvidersQuery());
        return Results.Ok(response);
    }
}
