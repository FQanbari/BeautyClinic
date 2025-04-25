using BeautyClinic.API.Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BeautyClinic.API.Infrastructure;

public class BeautyClinicDbContext : DbContext
{
    public BeautyClinicDbContext(DbContextOptions<BeautyClinicDbContext> options) : base(options)
    {
    }

    public DbSet<ClinicProvider> Providers { get; set; }
    public DbSet<ClinicService> Services { get; set; }
    public DbSet<ProviderService> ProviderServices { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<AppointmentService> AppointmentServices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Provider
        modelBuilder.Entity<ClinicProvider>()
        .HasKey(p => p.Id);
        modelBuilder.Entity<ClinicProvider>()
        .Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(200);
        
        // Service
        modelBuilder.Entity<ClinicService>()
        .HasKey(s => s.Id);
        modelBuilder.Entity<ClinicService>()
        .Property(s => s.Name)
        .IsRequired()
        .HasMaxLength(200);

        // ProviderService
        modelBuilder.Entity<ProviderService>()
        .HasKey(ps => ps.Id);
        modelBuilder.Entity<ProviderService>()
        .HasOne(ps => ps.ClinicProvider)
        .WithMany(p => p.ProviderServices)
        .HasForeignKey(ps => ps.ProviderId);
        modelBuilder.Entity<ProviderService>()
        .HasOne(ps => ps.ClinicService)
        .WithMany(s => s.ProviderServices)
        .HasForeignKey(ps => ps.ServiceId);
        modelBuilder.Entity<ProviderService>()
        .Property(ps => ps.Gender)
        .IsRequired();
        modelBuilder.Entity<ProviderService>()
        .Property(ps => ps.Description)
        .HasMaxLength(500);

        // Customer
        modelBuilder.Entity<Customer>()
        .HasKey(c => c.Id);
        modelBuilder.Entity<Customer>()
        .Property(c => c.FirstName)
        .IsRequired()
        .HasMaxLength(100);
        modelBuilder.Entity<Customer>()
        .Property(c => c.LastName)
        .IsRequired()
        .HasMaxLength(100);
        modelBuilder.Entity<Customer>()
        .Property(c => c.Mobile)
        .IsRequired()
        .HasMaxLength(20);

        // Appointment
        modelBuilder.Entity<Appointment>()
        .HasKey(a => a.Id);
        modelBuilder.Entity<Appointment>()
        .HasOne(a => a.ClinicProvider)
        .WithMany(p => p.Appointments)
        .HasForeignKey(a => a.ProviderId);
        modelBuilder.Entity<Appointment>()
        .HasOne(a => a.Customer)
        .WithMany(c => c.Appointments)
        .HasForeignKey(a => a.CustomerId)
        .IsRequired(false);
        modelBuilder.Entity<Appointment>()
        .Property(a => a.FirstName)
        .HasMaxLength(100);
        modelBuilder.Entity<Appointment>()
        .Property(a => a.LastName)
        .HasMaxLength(100);
        modelBuilder.Entity<Appointment>()
        .Property(a => a.Mobile)
        .HasMaxLength(20);

        // AppointmentService
        modelBuilder.Entity<AppointmentService>()
        .HasKey(asp => new { asp.AppointmentId, asp.ServiceId });
        modelBuilder.Entity<AppointmentService>()
        .HasOne(asp => asp.Appointment)
        .WithMany(a => a.AppointmentServices)
        .HasForeignKey(asp => asp.AppointmentId);
        modelBuilder.Entity<AppointmentService>()
        .HasOne(asp => asp.ClinicService)
        .WithMany(s => s.AppointmentServices)
        .HasForeignKey(asp => asp.ServiceId);

        // Seed Data
        SeedData.Seed(modelBuilder);        
    }
    
}
