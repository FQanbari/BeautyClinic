using BeautyClinic.API.Common.Endpoints.Enums;
using BeautyClinic.API.Common.Models;

namespace BeautyClinic.API.Infrastructure;

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Providers
        modelBuilder.Entity<ClinicProvider>().HasData(
        new ClinicProvider { Id = 1, Name = "لیزر Adss 2024 با 4 طول موج", IsActive = true },
        new ClinicProvider { Id = 2, Name = "دستگاه کویتیلاقری", IsActive = true }
        );

        // Services
        modelBuilder.Entity<ClinicService>().HasData(
        new ClinicService { Id = 1, Name = "کل بدن", Description = null },
        new ClinicService { Id = 17, Name = "سرویس ناشناخته", Description = null }
        );

        // ProviderServices
        modelBuilder.Entity<ProviderService>().HasData(
        new ProviderService
        {
            Id = 1,
            ProviderId = 1,
            ProviderName = "لیزر Adss 2024 با 4 طول موج",
            ServiceId = 1,
            ServiceName = "کل بدن",
            Gender = Gender.Female,
            TimeSpan = 60,
            Description = "",
            OrderIndex = 1
        }
        );

        // Customers
        modelBuilder.Entity<Customer>().HasData(
        new Customer
        {
            Id = 1,
            FirstName = "فاطمه",
            LastName = "احمدی",
            Mobile = "09109566150",
            Code = ""
        }
        );

        // Appointments
        modelBuilder.Entity<Appointment>().HasData(
        // From GetAppointments
        new Appointment
        {
            Id = 1,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 19), // 1404/1/27
            StartHour = 9,
            StartMinute = 0,
            EndHour = 10,
            EndMinute = 0,
            TimeSpanMinute = 60,
            Status = AppointmentStatus.Available,
            CustomerId = null
        },
        new Appointment
        {
            Id = 2,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 19),
            StartHour = 10,
            StartMinute = 0,
            EndHour = 10,
            EndMinute = 40,
            TimeSpanMinute = 40,
            Status = AppointmentStatus.Available,
            CustomerId = null
        },
        new Appointment
        {
            Id = 3,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 20),
            StartHour = 10,
            StartMinute = 40,
            EndHour = 11,
            EndMinute = 0,
            TimeSpanMinute = 20,
            Status = AppointmentStatus.Available,
            CustomerId = null
        },
        new Appointment
        {
            Id = 4,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 20),
            StartHour = 11,
            StartMinute = 0,
            EndHour = 11,
            EndMinute = 20,
            TimeSpanMinute = 20,
            Status = AppointmentStatus.Available,
            CustomerId = null
        },
        new Appointment
        {
            Id = 5,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 20),
            StartHour = 11,
            StartMinute = 20,
            EndHour = 11,
            EndMinute = 35,
            TimeSpanMinute = 15,
            Status = AppointmentStatus.Available,
            CustomerId = null
        },
        new Appointment
        {
            Id = 6,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 20),
            StartHour = 11,
            StartMinute = 35,
            EndHour = 11,
            EndMinute = 55,
            TimeSpanMinute = 20,
            Status = AppointmentStatus.Available,
            CustomerId = null
        },
        new Appointment
        {
            Id = 7,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 20),
            StartHour = 11,
            StartMinute = 55,
            EndHour = 12,
            EndMinute = 5,
            TimeSpanMinute = 10,
            Status = AppointmentStatus.Available,
            CustomerId = null
        },
        new Appointment
        {
            Id = 8,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 20),
            StartHour = 12,
            StartMinute = 5,
            EndHour = 12,
            EndMinute = 45,
            TimeSpanMinute = 40,
            Status = AppointmentStatus.Reserved,
            CustomerId = null
        },
        new Appointment
        {
            Id = 9,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 20),
            StartHour = 13,
            StartMinute = 5,
            EndHour = 13,
            EndMinute = 15,
            TimeSpanMinute = 10,
            Status = AppointmentStatus.Available,
            CustomerId = null
        },
        new Appointment
        {
            Id = 10,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 20),
            StartHour = 13,
            StartMinute = 15,
            EndHour = 13,
            EndMinute = 55,
            TimeSpanMinute = 40,
            Status = AppointmentStatus.Reserved,
            CustomerId = null
        },
        new Appointment
        {
            Id = 11,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 20),
            StartHour = 14,
            StartMinute = 20,
            EndHour = 14,
            EndMinute = 35,
            TimeSpanMinute = 15,
            Status = AppointmentStatus.Available,
            CustomerId = null
        },
        new Appointment
        {
            Id = 12,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 20),
            StartHour = 14,
            StartMinute = 35,
            EndHour = 14,
            EndMinute = 55,
            TimeSpanMinute = 20,
            Status = AppointmentStatus.Available,
            CustomerId = null
        },
        new Appointment
        {
            Id = 13,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 20),
            StartHour = 14,
            StartMinute = 55,
            EndHour = 15,
            EndMinute = 5,
            TimeSpanMinute = 10,
            Status = AppointmentStatus.Available,
            CustomerId = null
        },
        new Appointment
        {
            Id = 14,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 20),
            StartHour = 15,
            StartMinute = 35,
            EndHour = 16,
            EndMinute = 35,
            TimeSpanMinute = 60,
            Status = AppointmentStatus.Available,
            CustomerId = null
        },
        new Appointment
        {
            Id = 15,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 20),
            StartHour = 16,
            StartMinute = 35,
            EndHour = 17,
            EndMinute = 15,
            TimeSpanMinute = 40,
            Status = AppointmentStatus.Reserved,
            CustomerId = null
        },
        new Appointment
        {
            Id = 16,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 20),
            StartHour = 17,
            StartMinute = 15,
            EndHour = 17,
            EndMinute = 55,
            TimeSpanMinute = 40,
            Status = AppointmentStatus.Reserved,
            CustomerId = null
        },
        new Appointment
        {
            Id = 17,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 20),
            StartHour = 17,
            StartMinute = 55,
            EndHour = 18,
            EndMinute = 35,
            TimeSpanMinute = 40,
            Status = AppointmentStatus.Reserved,
            CustomerId = null
        },
        new Appointment
        {
            Id = 18,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 20),
            StartHour = 18,
            StartMinute = 40,
            EndHour = 19,
            EndMinute = 20,
            TimeSpanMinute = 40,
            Status = AppointmentStatus.Available,
            CustomerId = null
        },
        new Appointment
        {
            Id = 19,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 20),
            StartHour = 19,
            StartMinute = 20,
            EndHour = 20,
            EndMinute = 20,
            TimeSpanMinute = 60,
            Status = AppointmentStatus.Available,
            CustomerId = null
        },
        new Appointment
        {
            Id = 20,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 20),
            StartHour = 20,
            StartMinute = 20,
            EndHour = 21,
            EndMinute = 0,
            TimeSpanMinute = 40,
            Status = AppointmentStatus.Available,
            CustomerId = null
        },
        // از SaveAppointment
        new Appointment
        {
            Id = 21,
            ProviderId = 2,
            Date = new DateTime(2025, 4, 20),
            StartHour = 12,
            StartMinute = 5,
            EndHour = 12,
            EndMinute = 45,
            TimeSpanMinute = 40,
            Status = AppointmentStatus.Available,
            CustomerId = 1,
            FirstName = "فاطمه",
            LastName = "احمدی",
            Mobile = "09109566150",
            Code = ""
        }
        );

        // AppointmentServices
        modelBuilder.Entity<AppointmentService>().HasData(
        new AppointmentService { AppointmentId = 8, ServiceId = 17 },
        new AppointmentService { AppointmentId = 10, ServiceId = 17 },
        new AppointmentService { AppointmentId = 15, ServiceId = 17 },
        new AppointmentService { AppointmentId = 16, ServiceId = 17 },
        new AppointmentService { AppointmentId = 17, ServiceId = 17 },
        new AppointmentService { AppointmentId = 21, ServiceId = 17 }
        );
    }
}