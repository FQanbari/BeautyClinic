using BeautyClinic.API.Endpoints.Internal;
using BeautyClinic.API.Models;
using FluentValidation.Results;
using System.Net.Mime;
using FluentValidation.Results;
using FluentValidation;


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
        app.MapGet(BaseRoute, GetAllClinicProviderAsync)
            .WithName("GetAllClinicProvider")
            .Produces<IEnumerable<ClinicProvider>>(200)
            .WithTags(Tag);

    }

    private static async Task<IResult> GetAllClinicProviderAsync()
    {
        var providers = new List<ClinicProvider>
        {
            new ClinicProvider
            {
                Id = 1,
                Title = "لیزر Adss 2024 با 4 طول موج",
                IsActive = true
            },
            new ClinicProvider
            {
                Id = 2,
                Title = "دستگاه تیتانیوم وارداتی  (سه طول موج الکس ، دایود ، ایندیاگ)",
                IsActive = true
            }
        };
        return Results.Ok(providers);
    }
}
