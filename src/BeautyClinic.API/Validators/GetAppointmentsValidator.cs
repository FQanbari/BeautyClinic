using BeautyClinic.API.Features.Appointments.GetAppointments;

namespace BeautyClinic.API.Validators;

public class GetAppointmentsValidator : AbstractValidator<GetAppointmentsQuery>
{
    public GetAppointmentsValidator()
    {
        RuleFor(x => x.ProviderId)
        .GreaterThan(0)
        .WithMessage("Provider must be greater than zero.");

        RuleFor(x => x.ServiceIds)
        .ForEach(id => id.GreaterThan(0))
        .WithMessage("Service must be greater than zero.");

        RuleFor(x => x.Year)
        .InclusiveBetween(1405, 1410)
        .WithMessage("Year is not valid.");

        RuleFor(x => x.Month)
        .InclusiveBetween(1, 12)
        .WithMessage("Month is not valid.");

        RuleFor(x => x.Day)
        .InclusiveBetween(1, 31)
        .WithMessage("Day is not valid.");

        RuleFor(x => x)
        .Must(x => IsValidDate(x.Year, x.Month, x.Day))
        .WithMessage("Date is not valid.");
    }

    private bool IsValidDate(int year, int month, int day)
    {
        try
        {
            new DateTime(year, month, day);
            return true;
        }
        catch
        {
            return false;
        }
    }
}