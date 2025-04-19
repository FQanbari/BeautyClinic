namespace BeautyClinic.API.Features.Services.GetAllProviderServices;

public class ProviderServiceDto
{
    public int Id { get; set; }
    public int ProviderId { get; set; }
    public int ServiceId { get; set; }
    public string ProviderName { get; set; } = string.Empty;
    public string ServiceName { get; set; } = string.Empty;
    public int TimeSpan { get; set; }
    public int GenderId { get; set; }
    public string Description { get; set; } = string.Empty;
    public int OrderIndex { get; set; }
}
