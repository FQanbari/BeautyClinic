## 🏥 BeautyClinic API

A **RESTful API** for managing a beauty clinic, built with **ASP.NET Core** using **Minimal APIs**, **Vertical Slice Architecture (VSA)**, **CQRS**, and **MediatR**.
It supports managing **appointments**, **clinic providers**, and **services**, with **Entity Framework Core** for database operations, **FluentValidation** for input validation, and automated **integration tests** for quality assurance.

---

### 🚀 Features

✅ **Appointments**

* Retrieve appointments: `POST /Appointments/GetAppointments`
* Save appointment: `POST /Appointments/SaveAppointment`

✅ **Clinic Providers**

* Get all providers: `GET /ClinicProvider`

✅ **Clinic Services**

* Get provider services: `POST /ClinicService`

✅ **Validation**

* Input validation with **FluentValidation**

✅ **Error Handling**

* Centralized error handling via **custom middleware**

✅ **Database**

* **SQL Server** with seed data

✅ **Minimal API**

* Uses **Minimal API** approach for endpoint registration

✅ **Testing**

* **Integration tests** implemented for end-to-end verification

---

### 🏗️ Architecture

* **ASP.NET Core**
* **Minimal API**
* **Entity Framework Core**
* **MediatR (CQRS)**
* **FluentValidation**
* **Vertical Slice Architecture**

👉 See the **C4 Context Diagram** and **Architecture Diagram** for a visual overview.
<p align="center">
  <img src="https://github.com/user-attachments/assets/4610f696-714a-4137-bca6-7d49a65a54e4" alt="context-diagram" width="600" />
</p>

---

### 📁 Project Structure

```
BeautyClinic.API/
├── Features/
│   ├── Appointments/
│   ├── ClinicProviders/
│   ├── ClinicServices/
├── Common/
├── Infrastructure/
├── Endpoints/
├── Program.cs
├── appsettings.json
└── BeautyClinic.API.csproj
```

---

### ⚙️ Setup

1. **Clone the repo:**

   ```bash
   git clone https://github.com/FQanbari/BeautyClinic.git
   ```

2. **Configure database:**

   * Update `appsettings.json` with your SQL Server connection string.

3. **Apply migrations:**

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. **Run the app:**

   ```bash
   dotnet run
   ```

   Default URL: `https://localhost:5001`

---

### 🧪 Running Tests

Integration tests are located under the `/Tests` folder:

```bash
dotnet test
```

✅ Tests cover **API endpoints** and **database interactions**.

---

### 🗺️ API Endpoints

| Action                | Method | URL                              |
| --------------------- | ------ | -------------------------------- |
| Get Appointments      | POST   | /Appointments/GetAppointments |
| Save Appointment      | POST   | /Appointments/SaveAppointment |
| Get All Providers     | GET    | /ClinicProvider                  |
| Get Provider Services | POST   | /ClinicService                   |

---

### ⚠️ Known Limitations

* ❌ No authentication/authorization
* ❌ No concurrency handling for overlapping bookings
* ❌ No OpenAPI/Swagger documentation
* ❌ Limited logging
* ⚠️ Reflection-based endpoint registration may affect performance

---

### 💡 Future Improvements

* Add **JWT Authentication**
* Implement **concurrency handling** to prevent *Race Condition*
* Integrate **Swagger/OpenAPI** for documentation
* Optimize endpoint registration (remove reflection)
* Add structured logging with **Serilog**

## Contributing
1. Fork the repo.
2. Create a branch (`git checkout -b feature/YourFeature`).
3. Commit changes (`git commit -m "Your message"`).
4. Push (`git push origin feature/YourFeature`).
5. Open a pull request.

## License
MIT License. See [LICENSE](LICENSE) for details.

