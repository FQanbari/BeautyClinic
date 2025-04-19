using BeautyClinic.API.Features.Providers.Models;
using FluentAssertions;

namespace BeautyClinic.API.Test.Integration;

public class ClinicProviderEndpointsTests
{
    [Fact]
    public async Task GetAllClinicProvider_ReturnAllClinicProviders_WhenClinicProviderExist()
    {
        // Arrange
        var httpclient = _factory.CreateClient();
        var ClinicProvider = GenerateClinicProvider();
        await httpclient.PostAsJsonAsync("/ClinicProviders", ClinicProvider);
        _createdIsbns.Add(ClinicProvider.Isbn);
        var ClinicProviders = new List<ClinicProvider> { ClinicProvider };

        // Act
        var result = await httpclient.GetAsync($"/ClinicProviders");
        var returnedClinicProviders = await result.Content.ReadFromJsonAsync<List<ClinicProvider>>();

        // Assert
        result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        returnedClinicProviders.Should().BeEquivalentTo(ClinicProviders);
    }

    [Fact]
    public async Task GetAllClinicProvider_ReturnNoClinicProviders_WhenNoClinicProviderExist()
    {
        // Arrange
        var httpclient = _factory.CreateClient();

        // Act
        var result = await httpclient.GetAsync($"/ClinicProviders");
        var returnedClinicProviders = await result.Content.ReadFromJsonAsync<List<ClinicProvider>>();

        // Assert
        result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        returnedClinicProviders.Should().BeEmpty();
    }
}
