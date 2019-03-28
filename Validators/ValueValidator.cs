using FluentValidation;
using FluentValidationDescriptorEndpoint.Models;

namespace FluentValidationDescriptorEndpoint.Validators
{
    public class ValueValidator : AbstractValidator<Value>
    {
        public ValueValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().WithSeverity(Severity.Warning);
            RuleFor(v => v.Name).MaximumLength(100);
            RuleFor(v => v.Amount).NotEqual(10);
            RuleFor(v => v.Amount).GreaterThanOrEqualTo(0);
        }
    }
}
