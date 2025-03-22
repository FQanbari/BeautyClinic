using BeautyClinic.API.Models;
using FluentValidation;

namespace BeautyClinic.API.Validators;

public class ClinicProviderValidators : AbstractValidator<ClinicProvider>
{
    public ClinicProviderValidators()
    {
        RuleFor(x => x.Title).NotEmpty();
    }
}
