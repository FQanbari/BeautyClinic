using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyClinic.API.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Code", "FirstName", "LastName", "Mobile" },
                values: new object[] { 1, "", "فاطمه", "احمدی", "09109566150" });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "CreatedOn", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "لیزر Adss 2024 با 4 طول موج" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "دستگاه کویتیلاقری" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedOn", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "کل بدن" },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "سرویس ناشناخته" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Code", "CustomerId", "Date", "EndHour", "EndMinute", "FirstName", "LastName", "Mobile", "ProviderId", "StartHour", "StartMinute", "Status", "TimeSpanMinute" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 0, null, null, null, 2, 9, 0, 1, 60 },
                    { 2, null, null, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 40, null, null, null, 2, 10, 0, 1, 40 },
                    { 3, null, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 0, null, null, null, 2, 10, 40, 1, 20 },
                    { 4, null, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 20, null, null, null, 2, 11, 0, 1, 20 },
                    { 5, null, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 35, null, null, null, 2, 11, 20, 1, 15 },
                    { 6, null, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 55, null, null, null, 2, 11, 35, 1, 20 },
                    { 7, null, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 5, null, null, null, 2, 11, 55, 1, 10 },
                    { 8, null, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 45, null, null, null, 2, 12, 5, 0, 40 },
                    { 9, null, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 15, null, null, null, 2, 13, 5, 1, 10 },
                    { 10, null, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 55, null, null, null, 2, 13, 15, 0, 40 },
                    { 11, null, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 35, null, null, null, 2, 14, 20, 1, 15 },
                    { 12, null, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 55, null, null, null, 2, 14, 35, 1, 20 },
                    { 13, null, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 5, null, null, null, 2, 14, 55, 1, 10 },
                    { 14, null, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 35, null, null, null, 2, 15, 35, 1, 60 },
                    { 15, null, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 15, null, null, null, 2, 16, 35, 0, 40 },
                    { 16, null, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 55, null, null, null, 2, 17, 15, 0, 40 },
                    { 17, null, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 35, null, null, null, 2, 17, 55, 0, 40 },
                    { 18, null, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 20, null, null, null, 2, 18, 40, 1, 40 },
                    { 19, null, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 20, null, null, null, 2, 19, 20, 1, 60 },
                    { 20, null, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 0, null, null, null, 2, 20, 20, 1, 40 },
                    { 21, "", 1, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 45, "فاطمه", "احمدی", "09109566150", 2, 12, 5, 1, 40 }
                });

            migrationBuilder.InsertData(
                table: "ProviderServices",
                columns: new[] { "Id", "Description", "Gender", "OrderIndex", "ProviderId", "ProviderName", "ServiceId", "ServiceName", "TimeSpan" },
                values: new object[] { 1, "", 1, 1, 1, "لیزر Adss 2024 با 4 طول موج", 1, "کل بدن", 60 });

            migrationBuilder.InsertData(
                table: "AppointmentServices",
                columns: new[] { "AppointmentId", "ServiceId" },
                values: new object[,]
                {
                    { 8, 17 },
                    { 10, 17 },
                    { 15, 17 },
                    { 16, 17 },
                    { 17, 17 },
                    { 21, 17 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppointmentServices",
                keyColumns: new[] { "AppointmentId", "ServiceId" },
                keyValues: new object[] { 8, 17 });

            migrationBuilder.DeleteData(
                table: "AppointmentServices",
                keyColumns: new[] { "AppointmentId", "ServiceId" },
                keyValues: new object[] { 10, 17 });

            migrationBuilder.DeleteData(
                table: "AppointmentServices",
                keyColumns: new[] { "AppointmentId", "ServiceId" },
                keyValues: new object[] { 15, 17 });

            migrationBuilder.DeleteData(
                table: "AppointmentServices",
                keyColumns: new[] { "AppointmentId", "ServiceId" },
                keyValues: new object[] { 16, 17 });

            migrationBuilder.DeleteData(
                table: "AppointmentServices",
                keyColumns: new[] { "AppointmentId", "ServiceId" },
                keyValues: new object[] { 17, 17 });

            migrationBuilder.DeleteData(
                table: "AppointmentServices",
                keyColumns: new[] { "AppointmentId", "ServiceId" },
                keyValues: new object[] { 21, 17 });

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
