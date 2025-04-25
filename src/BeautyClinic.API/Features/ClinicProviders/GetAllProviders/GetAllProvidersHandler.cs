using BeautyClinic.API.Common;
using MediatR;

namespace BeautyClinic.API.Features.Providers.GetAllProviders;

public class GetAllProvidersHandler : IRequestHandler<GetAllProvidersQuery, ApiResponse<List<ClinicProviderDto>>>
{
    private readonly BeautyClinicDbContext _dbContext;

    public GetAllProvidersHandler(BeautyClinicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ApiResponse<List<ClinicProviderDto>>> Handle(GetAllProvidersQuery request, CancellationToken cancellationToken)
    {
        var providers = await _dbContext.Providers
            .Select(p => new ClinicProviderDto
            {
                Id = p.Id,
                Value = p.Name,
                IsChecked = p.IsActive
            })
            .ToListAsync(cancellationToken);

        return new ApiResponse<List<ClinicProviderDto>>
        {
            Succeeded = true,
            Data = providers
        };
    }
}
