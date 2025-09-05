namespace Cyberspace.Model.Validators;

using System;
using FluentValidation;
using Cyberspace.Model;

public class PaymentDtoValidator: AbstractValidator<Model.PaymentDto>
{
    public PaymentDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Pan).NotEmpty().NotNull().MaximumLength(16).MinimumLength(16).WithMessage("Pan must be 16 characters");
        RuleFor(x => x.Cvv).NotEmpty().NotNull().MaximumLength(4).MinimumLength(4).WithMessage("CVV must be 4 characters");
        RuleFor(x => x.Expiry).NotEmpty().NotNull().MaximumLength(4).MinimumLength(4).WithMessage("Expiry must be 4 characters");
        RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero");
    }
}
