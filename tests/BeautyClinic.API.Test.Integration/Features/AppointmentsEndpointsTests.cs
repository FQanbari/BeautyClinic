using BeautyClinic.API.Common;
using BeautyClinic.API.Common.Endpoints.Enums;
using BeautyClinic.API.Features.Appointments.GetAppointments;
using BeautyClinic.API.Features.Appointments.SaveAppointment;

namespace BeautyClinic.API.Test.Integration.Features;

public class AppointmentsEndpointsTests : IClassFixture<BeautyClinicApiFactory>, IAsyncLifetime
{
    private readonly BeautyClinicApiFactory _factory;
    private HttpClient _client;

    public AppointmentsEndpointsTests(BeautyClinicApiFactory factory)
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
    public async Task GetAppointments_ReturnsSuccess_WhenValidRequest()
    {
        // Arrange
        var client = _factory.CreateClient();
        var requestDto = new GetAppointmentsRequestDto
        {
            ProviderId = 1,
            ServiceIds = new List<int> { 1 },
            Year = 2025,
            Month = 4,
            Day = 19
        };

        // Act
        var response = await client.PostAsJsonAsync("/v1/Appointments/GetAppointments", requestDto);

        // Assert
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<List<AppointmentDto>>>();
        Assert.NotNull(apiResponse);
        Assert.True(apiResponse.Succeeded);
        Assert.NotEmpty(apiResponse.Data);
    }

    [Fact]
    public async Task SaveAppointment_ReturnsSuccess_WhenValidRequest()
    {
        // Arrange
        var client = _factory.CreateClient();
        var requestDto = new SaveAppointmentRequestDto
        {
            Year = 2025,
            Month = 4,
            Day = 19,
            StartHour = 9,
            StartMinute = 0,
            EndHour = 10,
            EndMinute = 0,
            TimeSpanMinute = 60,
            ProviderId = 2,
            ServiceIds = new List<int> { 17 },
            CustomerId = 1,
            Status = AppointmentStatus.Available,
            FirstName = "فاطمه",
            LastName = "احمدی",
            Mobile = "09109566150",
            Code = ""
        };

        // Act
        var response = await client.PostAsJsonAsync("/Appointments/SaveAppointment", requestDto);

        // Assert
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<SaveAppointmentResponseDto>>();
        Assert.NotNull(apiResponse);
        Assert.True(apiResponse.Succeeded);
        Assert.NotNull(apiResponse.Data);
        Assert.Equal(requestDto.StartHour, apiResponse.Data.StartHour);
    }

    [Fact]
    public async Task GetAppointments_ReturnsBadRequest_WhenInvalidRequest()
    {
        // Arrange
        var client = _factory.CreateClient();
        var requestDto = new GetAppointmentsRequestDto
        {
            ProviderId = -1, // Invalid ProviderId
            ServiceIds = new List<int> { 1 },
            Year = 2025,
            Month = 4,
            Day = 19
        };

        // Act
        var response = await client.PostAsJsonAsync("/Appointments/GetAppointments", requestDto);

        // Assert
        Assert.False(response.IsSuccessStatusCode);
        //var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<List<AppointmentDto>>>();
        //Assert.NotNull(apiResponse);
        //Assert.False(apiResponse.Succeeded);
        //Assert.Null(apiResponse.Data);
    }

    [Fact]
    public async Task SaveAppointment_ReturnsBadRequest_WhenInvalidRequest()
    {
        // Arrange
        var client = _factory.CreateClient();
        var requestDto = new SaveAppointmentRequestDto
        {
            Year = 2025,
            Month = 4,
            Day = 19,
            StartHour = -1, // Invalid StartHour
            StartMinute = 0,
            EndHour = 10,
            EndMinute = 0,
            TimeSpanMinute = 60,
            ProviderId = 1,
            ServiceIds = new List<int> { 1 },
            CustomerId = 1,
            Status = AppointmentStatus.Available,
            FirstName = "فاطمه",
            LastName = "احمدی",
            Mobile = "09109566150",
            Code = ""
        };

        // Act
        var response = await client.PostAsJsonAsync("/Appointments/SaveAppointment", requestDto);

        // Assert
        Assert.False(response.IsSuccessStatusCode);
        //var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<SaveAppointmentResponseDto>>();
        //Assert.NotNull(apiResponse);
        //Assert.False(apiResponse.Succeeded);
    }
}
