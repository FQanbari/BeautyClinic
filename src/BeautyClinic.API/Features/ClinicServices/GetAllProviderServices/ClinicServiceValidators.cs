using BeautyClinic.API.Common.Models;
using FluentValidation;

namespace BeautyClinic.API.Features.ClinicServices.GetAllProviderServices;

public class ClinicProviderValidators : AbstractValidator<ClinicProvider>
{
    public ClinicProviderValidators()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
