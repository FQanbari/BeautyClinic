using BeautyClinic.API.Common;
using BeautyClinic.API.Common.Endpoints.Enums;
using BeautyClinic.API.Features.Services.GetAllProviderServices;
using FluentAssertions;

namespace BeautyClinic.API.Test.Integration.Features;

public class ClinicServicesEndpointsTests : IClassFixture<BeautyClinicApiFactory>, IAsyncLifetime
{
    private readonly BeautyClinicApiFactory _factory;
    private HttpClient _client;

    public ClinicServicesEndpointsTests(BeautyClinicApiFactory factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    public Task InitializeAsync() => Task.CompletedTask;

    public async Task DisposeAsync()
    {
        _client.Dispose();
        await Task.CompletedTask;
    }

    [Fact]
    public async Task GetAllProviderServices_ReturnsExpectedData()
    {
        // Arrange
        var query = new GetAllProviderServicesQuery
        {
            ProviderId = 1,
            GenderId = (int)Gender.Female
        };

        // Act
        var response = await _client.PostAsJsonAsync("/ClinicService", query);

        // Assert
        response.EnsureSuccessStatusCode(); // 200 expected

        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<List<ProviderServiceDto>>>();

        apiResponse.Should().NotBeNull();
        apiResponse!.Data.Should().NotBeNull();
        apiResponse.Data.Should().NotBeEmpty();
        apiResponse.Data.Should().ContainSingle(x => x.ProviderId == 1 && x.ServiceId == 1);

        apiResponse.Data.Count.Should().Be(1);
    }

    [Fact]
    public async Task GetAllProviderServices_WithInvalidQuery_ReturnsEmptyData()
    {
        var query = new GetAllProviderServicesQuery();

        var response = await _client.PostAsJsonAsync("/ClinicService", query);

        response.EnsureSuccessStatusCode();

        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<List<ProviderServiceDto>>>();

        apiResponse.Should().NotBeNull();
        apiResponse!.Data.Should().NotBeNull();

         apiResponse.Data.Should().BeEmpty();

        //apiResponse.Data.Should().NotBeEmpty();
    }
}
