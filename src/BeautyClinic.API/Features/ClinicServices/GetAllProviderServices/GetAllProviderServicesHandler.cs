using BeautyClinic.API.Common;
using BeautyClinic.API.Common.Endpoints.Enums;

namespace BeautyClinic.API.Features.Services.GetAllProviderServices;

public class GetAllProviderServicesHandler : IRequestHandler<GetAllProviderServicesQuery, ApiResponse<List<ProviderServiceDto>>>
{
    private readonly BeautyClinicDbContext _dbContext;

    public GetAllProviderServicesHandler(BeautyClinicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ApiResponse<List<ProviderServiceDto>>> Handle(GetAllProviderServicesQuery request, CancellationToken cancellationToken)
    {
        var services = await _dbContext.ProviderServices
        .Where(ps => ps.ProviderId == request.ProviderId && ps.Gender == (Gender)request.GenderId)
        .OrderBy(ps => ps.OrderIndex)
        .Select(ps => new ProviderServiceDto
        {
            Id = ps.Id,
            ProviderId = ps.ProviderId,
            ServiceId = ps.ServiceId,
            ProviderName = ps.ClinicProvider.Name,
            ServiceName = ps.ClinicService.Name,
            TimeSpan = ps.TimeSpan,
            GenderId = (int)ps.Gender,
            Description = ps.Description ?? string.Empty,
            OrderIndex = ps.OrderIndex
        })
        .ToListAsync(cancellationToken);

        return new ApiResponse<List<ProviderServiceDto>>
        {
            Succeeded = true,
            Data = services
        };
    }
}