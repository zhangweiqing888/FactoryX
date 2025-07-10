using FactoryX.Application.DTOs.Requests.OperatorRequests;
using FluentValidation;

namespace FactoryX.Application.Validators.OperatorRequestValidators;

public class UpdateOperatorRequestValidator : AbstractValidator<UpdateOperatorRequest>
{
    public UpdateOperatorRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Machine name cannot be empty.");

        RuleFor(x => x.EmployeeNumber)
            .NotEmpty()
            .WithMessage("Machine status cannot be empty.");
    }
}