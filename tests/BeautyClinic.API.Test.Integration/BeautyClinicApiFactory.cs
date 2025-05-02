using BeautyClinic.API.Common.Models;
using BeautyClinic.API.Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BeautyClinic.API.Test.Integration;

public class BeautyClinicApiFactory : WebApplicationFactory<IApiMarker>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=BeautyClinicTestDb;Trusted_Connection=True;";

            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<BeautyClinicDbContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<BeautyClinicDbContext>(options =>
                options.UseSqlServer(connectionString));

            var sp = services.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<BeautyClinicDbContext>();

                db.Database.EnsureCreated();
            }
        });
    }

}
