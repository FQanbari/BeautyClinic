using BeautyClinic.API.Common;
using BeautyClinic.API.Common.Models;
using BeautyClinic.API.Features.Providers.GetAllProviders;
using FluentAssertions;
using System.Net;

namespace BeautyClinic.API.Test.Integration.Features;

public class ClinicProviderEndpointsTests : IClassFixture<BeautyClinicApiFactory>, IAsyncLifetime
{
    private readonly BeautyClinicApiFactory _factory;
    private HttpClient _client;

    public ClinicProviderEndpointsTests(BeautyClinicApiFactory factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }


    [Fact(DisplayName = "GET /ClinicProvider returns 200 OK")]
    public async Task GetAllClinicProvider_Returns200OK()
    {
        // Act
        var response = await _client.GetAsync("/ClinicProvider");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact(DisplayName = "GET /ClinicProvider returns application/json")]
    public async Task GetAllClinicProvider_ReturnsJsonContentType()
    {
        // Act
        var response = await _client.GetAsync("/ClinicProvider");

        // Assert
        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
    }

    [Fact(DisplayName = "GET /ClinicProvider returns seeded providers")]
    public async Task GetAllClinicProvider_ReturnsSeededProviders()
    {
        // Act
        var apiResponse = await _client.GetFromJsonAsync<ApiResponse<List<ClinicProviderDto>>>("/ClinicProvider");

        // Assert
        Assert.NotNull(apiResponse);
        Assert.True(apiResponse.Succeeded);
        Assert.NotNull(apiResponse.Data);
        Assert.Equal(2, apiResponse.Data.Count);

        var provider1 = apiResponse.Data.FirstOrDefault(p => p.Id == 1);
        var provider2 = apiResponse.Data.FirstOrDefault(p => p.Id == 2);

        Assert.NotNull(provider1);
        Assert.Equal("لیزر Adss 2024 با 4 طول موج", provider1.Value);
        Assert.True(provider1.IsChecked);

        Assert.NotNull(provider2);
        Assert.Equal("دستگاه کویتیلاقری", provider2.Value);
        Assert.True(provider2.IsChecked);
    }

    [Fact(DisplayName = "GET /ClinicProvider returns ApiResponse wrapper")]
    public async Task GetAllClinicProvider_ReturnsApiResponseWrapper()
    {
        // Act
        var response = await _client.GetAsync("/ClinicProvider");

        // Deserialize
        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<List<ClinicProviderDto>>>();

        // Assert
        Assert.NotNull(apiResponse);
        Assert.True(apiResponse.Succeeded);
        Assert.Null(apiResponse.Message); 
    }
    public Task InitializeAsync() => Task.CompletedTask;

    public async Task DisposeAsync()
    {
        _client.Dispose();
        await Task.CompletedTask;
    }
}
