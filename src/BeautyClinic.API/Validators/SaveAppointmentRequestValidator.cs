using BeautyClinic.API.Features.Appointments.SaveAppointment;
using FluentValidation;

namespace BeautyClinic.API.Validators;

public class SaveAppointmentValidator : AbstractValidator<SaveAppointmentCommand>
{
    public SaveAppointmentValidator()
    {
        RuleFor(x => x.Year)
        .InclusiveBetween(1400, 1500).WithMessage("سال باید بین 1400 تا 1500 باشد.");

        RuleFor(x => x.Month)
        .InclusiveBetween(1, 12).WithMessage("ماه باید بین 1 تا 12 باشد.");

        RuleFor(x => x.Day)
        .InclusiveBetween(1, 31).WithMessage("روز باید بین 1 تا 31 باشد.");

        RuleFor(x => x)
        .Must(x => IsValidDate(x.Year, x.Month, x.Day))
        .WithMessage("تاریخ واردشده معتبر نیست.");

        RuleFor(x => x.StartHour)
        .InclusiveBetween(0, 23).WithMessage("ساعت شروع باید بین 0 تا 23 باشد.");

        RuleFor(x => x.StartMinute)
        .InclusiveBetween(0, 59).WithMessage("دقیقه شروع باید بین 0 تا 59 باشد.");

        RuleFor(x => x.EndHour)
        .InclusiveBetween(0, 23).WithMessage("ساعت پایان باید بین 0 تا 23 باشد.");

        RuleFor(x => x.EndMinute)
        .InclusiveBetween(0, 59).WithMessage("دقیقه پایان باید بین 0 تا 59 باشد.");

        RuleFor(x => x.TimeSpanMinute)
        .GreaterThan(0).WithMessage("مدت زمان باید بزرگ‌تر از صفر باشد.")
        .Must((dto, timeSpan) => IsValidTimeSpan(dto.StartHour, dto.StartMinute, dto.EndHour, dto.EndMinute, timeSpan))
        .WithMessage("مدت زمان با زمان شروع و پایان سازگار نیست.");

        RuleFor(x => x.ProviderId)
        .GreaterThan(0).WithMessage("شناسه ارائه‌دهنده باید بزرگ‌تر از صفر باشد.");

        RuleFor(x => x.ServiceIds)
        .NotEmpty().WithMessage("حداقل یک سرویس باید انتخاب شود.")
        .ForEach(id => id.GreaterThan(0).WithMessage("شناسه سرویس باید بزرگ‌تر از صفر باشد."));

        RuleFor(x => x.CustomerId)
        .GreaterThan(0).When(x => x.CustomerId.HasValue).WithMessage("شناسه مشتری باید بزرگ‌تر از صفر باشد.");

        RuleFor(x => x.FirstName)
        .NotEmpty().When(x => x.CustomerId == null || x.CustomerId == 0).WithMessage("نام مشتری الزامی است.")
        .MaximumLength(100).WithMessage("نام مشتری نمی‌تواند بیشتر از 100 کاراکتر باشد.");

        RuleFor(x => x.LastName)
        .NotEmpty().When(x => x.CustomerId == null || x.CustomerId == 0).WithMessage("نام خانوادگی مشتری الزامی است.")
        .MaximumLength(100).WithMessage("نام خانوادگی مشتری نمی‌تواند بیشتر از 100 کاراکتر باشد.");

        RuleFor(x => x.Mobile)
        .NotEmpty().When(x => x.CustomerId == null || x.CustomerId == 0).WithMessage("شماره موبایل الزامی است.")
        .Matches(@"^09[0-9]{9}$").WithMessage("شماره موبایل باید 11 رقمی و با 09 شروع شود.")
        .MaximumLength(20).WithMessage("شماره موبایل نمی‌تواند بیشتر از 20 کاراکتر باشد.");

        RuleFor(x => x.Code)
        .MaximumLength(50).WithMessage("کد نمی‌تواند بیشتر از 50 کاراکتر باشد.");

        RuleFor(x => x.Status)
        .IsInEnum().WithMessage("وضعیت باید یکی از مقادیر معتبر باشد.");
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
            return Math.Abs(calculatedTimeSpan - timeSpanMinute) < 1; // اجازه خطای کوچک
        }
        catch
        {
            return false;
        }
    }
}
