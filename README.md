# BeautyClinic API

## Overview
BeautyClinic API is a RESTful API for managing a beauty clinic, built with ASP.NET Core using **Vertical Slice Architecture (VSA)**, **CQRS**, and **MediatR**. It handles appointments, clinic providers, and services, using Entity Framework Core for database operations and FluentValidation for input validation.

## Features
- **Appointments**: Retrieve (`POST /v1/Appointments/GetAppointments`) and save (`POST /v1/Appointments/SaveAppointment`) appointments.
- **Clinic Providers**: Get all providers (`GET /ClinicProvider`).
- **Clinic Services**: Get provider services (`POST /ClinicService`).
- **Validation**: Input validation with FluentValidation.
- **Error Handling**: Centralized error handling via middleware.
- **Database**: SQL Server with seed data.
- **Endpoint Registration**: Automatic registration using `EndpointExtensions`.

## Project Structure
```
BeautyClinic.API/
├── Features/
│   ├── Appointments/          # Appointment features
│   ├── ClinicProviders/      # Provider features
│   ├── ClinicServices/       # Service features
├── Common/                   # Shared code (Models, Responses, Middleware)
├── Infrastructure/           # Database context
├── Program.cs
├── appsettings.json
└── BeautyClinic.API.csproj
```

## Technologies
- ASP.NET Core
- Entity Framework Core
- MediatR (CQRS)
- FluentValidation
- SQL Server
- Vertical Slice Architecture

## Setup
1. Clone the repo: `git clone <repository-url>`
2. Update `appsettings.json` with your SQL Server connection string.
3. Apply migrations: `dotnet ef migrations add InitialCreate` and `dotnet ef database update`.
4. Run: `dotnet run` (default URL: `https://localhost:5001`).

## API Endpoints
- **Get Appointments**: `POST /v1/Appointments/GetAppointments`
  - Body: `{"ProviderId": 2, "ServiceIds": [17], "Year": 2025, "Month": 4, "Day": 20}`
- **Save Appointment**: `POST /v1/Appointments/SaveAppointment`
  - Body: `{"Year": 2025, "Month": 4, "Day": 20, "StartHour": 12, "StartMinute": 5, ...}`
- **Get All Providers**: `GET /ClinicProvider`
- **Get Provider Services**: `POST /ClinicService`

## Limitations
- No authentication/authorization.
- No concurrency handling for bookings.
- No API documentation (e.g., Swagger).
- Performance concerns with Reflection in endpoint registration.
- Limited logging.

## Future Improvements
- Add authentication (JWT).
- Handle concurrency for bookings.
- Integrate Swagger for API documentation.
- Optimize performance (replace Reflection).
- Enhance logging.

## Contributing
1. Fork the repo.
2. Create a branch (`git checkout -b feature/YourFeature`).
3. Commit changes (`git commit -m "Your message"`).
4. Push (`git push origin feature/YourFeature`).
5. Open a pull request.

## License
MIT License. See [LICENSE](LICENSE) for details.

---

### توضیح
این نسخه خلاصه‌تر است و بخش‌های اضافی (مانند مثال‌های کامل API و تماس) حذف شده‌اند، اما همچنان اطلاعات ضروری پروژه، ساختار، نحوه اجرا، و محدودیت‌ها را پوشش می‌دهد. اگر نیاز به تغییرات بیشتری دارید، اطلاع دهید!
