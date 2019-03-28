using FluentValidation.Validators;
using FluentValidationDescriptorEndpoint.Models;

namespace FluentValidationDescriptorEndpoint.Mappers
{
    public class ValidationDescriptionMapper
    {
        public ValidationDescription Map(IPropertyValidator propertyValidator)
        {
            var validationDescription = new ValidationDescription
            {
                Validator = propertyValidator.GetType().Name,
                Severity = propertyValidator.Options.Severity.ToString()
            };

            if (propertyValidator is IComparisonValidator abstractComparison)
            {
                validationDescription.Comparison = new ComparisonDescription
                {
                    Type = abstractComparison.Comparison.ToString(),
                    Value = abstractComparison.ValueToCompare,
                    OtherMember = abstractComparison.MemberToCompare?.Name
                };
            }

            if (propertyValidator is ILengthValidator lengthValidator)
            {
                validationDescription.Length = new LengthDescription
                {
                    Min = lengthValidator.Min,
                    Max = lengthValidator.Max
                };
            }

            return validationDescription;
        }
    }
}
