namespace FluentValidationDescriptorEndpoint.Models
{
    public class ValidationDescription
    {
        public string Validator { get; set; }
        public string Severity { get; set; }
        public ComparisonDescription Comparison { get; set; } = new ComparisonDescription();
        public LengthDescription Length { get; set; } = new LengthDescription();
    }
}
