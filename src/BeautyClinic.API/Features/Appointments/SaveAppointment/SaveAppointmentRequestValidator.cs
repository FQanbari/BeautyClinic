using FluentValidation;

namespace BeautyClinic.API.Features.Appointments.SaveAppointment;

public class SaveAppointmentValidator : AbstractValidator<SaveAppointmentCommand>
{
    public SaveAppointmentValidator()
    {
        RuleFor(x => x.Year)
            .InclusiveBetween(2025, 2025).WithMessage("Year must be 2025.");

        RuleFor(x => x.Month)
            .InclusiveBetween(1, 12).WithMessage("Month must be between 1 and 12.");

        RuleFor(x => x.Day)
            .InclusiveBetween(1, 31).WithMessage("Day must be between 1 and 31.");

        RuleFor(x => x)
            .Must(x => IsValidDate(x.Year, x.Month, x.Day))
            .WithMessage("The entered date is not valid.");

        RuleFor(x => x.StartHour)
            .InclusiveBetween(0, 23).WithMessage("Start hour must be between 0 and 23.");

        RuleFor(x => x.StartMinute)
            .InclusiveBetween(0, 59).WithMessage("Start minute must be between 0 and 59.");

        RuleFor(x => x.EndHour)
            .InclusiveBetween(0, 23).WithMessage("End hour must be between 0 and 23.");

        RuleFor(x => x.EndMinute)
            .InclusiveBetween(0, 59).WithMessage("End minute must be between 0 and 59.");

        RuleFor(x => x.TimeSpanMinute)
            .GreaterThan(0).WithMessage("Duration must be greater than zero.")
            .Must((dto, timeSpan) => IsValidTimeSpan(dto.StartHour, dto.StartMinute, dto.EndHour, dto.EndMinute, timeSpan))
            .WithMessage("Duration is not consistent with start and end times.");

        RuleFor(x => x.ProviderId)
            .GreaterThan(0).WithMessage("Provider ID must be greater than zero.");

        RuleFor(x => x.ServiceIds)
            .NotEmpty().WithMessage("At least one service must be selected.")
            .ForEach(id => id.GreaterThan(0).WithMessage("Service ID must be greater than zero."));

        RuleFor(x => x.CustomerId)
            .GreaterThan(0).When(x => x.CustomerId.HasValue).WithMessage("Customer ID must be greater than zero.");

        RuleFor(x => x.FirstName)
            .NotEmpty().When(x => x.CustomerId == null || x.CustomerId == 0).WithMessage("Customer first name is required.")
            .MaximumLength(100).WithMessage("Customer first name cannot exceed 100 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().When(x => x.CustomerId == null || x.CustomerId == 0).WithMessage("Customer last name is required.")
            .MaximumLength(100).WithMessage("Customer last name cannot exceed 100 characters.");

        RuleFor(x => x.Mobile)
            .NotEmpty().When(x => x.CustomerId == null || x.CustomerId == 0).WithMessage("Mobile number is required.")
            .Matches(@"^09[0-9]{9}$").WithMessage("Mobile number must be 11 digits starting with 09.")
            .MaximumLength(20).WithMessage("Mobile number cannot exceed 20 characters.");

        RuleFor(x => x.Code)
            .MaximumLength(50).WithMessage("Code cannot exceed 50 characters.");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Status must be one of the valid values.");
    }

    private bool IsValidDate(int year, int month, int day)
    {
        try
        {
            var date = new DateTime(year, month, day, new System.Globalization.PersianCalendar());
            return true;
        }
        catch
        {
            return false;
        }
    }

    private bool IsValidTimeSpan(int startHour, int startMinute, int endHour, int endMinute, int timeSpanMinute)
    {
        try
        {
            var start = new TimeSpan(startHour, startMinute, 0);
            var end = new TimeSpan(endHour, endMinute, 0);
            var calculatedTimeSpan = (end - start).TotalMinutes;
            return Math.Abs(calculatedTimeSpan - timeSpanMinute) < 1; // Allow small margin of error
        }
        catch
        {
            return false;
        }
    }
}
