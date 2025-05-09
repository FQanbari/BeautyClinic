﻿using BeautyClinic.API.Common.Endpoints.Enums;

namespace BeautyClinic.API.Common.Models;

public class ProviderService
{
    public int Id { get; set; }
    public int ProviderId { get; set; }
    public int ServiceId { get; set; }
    public string ProviderName { get; set; }
    public string ServiceName { get; set; }
    public int TimeSpan { get; set; }
    public Gender Gender { get; set; }
    public string? Description { get; set; }
    public int OrderIndex { get; set; }

    public ClinicProvider ClinicProvider { get; set; } = null!;
    public ClinicService ClinicService { get; set; } = null!;

}
