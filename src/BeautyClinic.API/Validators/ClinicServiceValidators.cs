using BeautyClinic.API.Features.Providers.Models;
using FluentValidation;

namespace BeautyClinic.API.Validators;

public class ClinicProviderValidators : AbstractValidator<ClinicProvider>
{
    public ClinicProviderValidators()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
