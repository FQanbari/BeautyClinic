using BeautyClinic.API.Common;

namespace BeautyClinic.API.Features.Services.GetAllProviderServices;

public class GetAllProviderServicesQuery : IRequest<ApiResponse<List<ProviderServiceDto>>>
{
    public int ProviderId { get; set; }
    public int GenderId { get; set; }
}