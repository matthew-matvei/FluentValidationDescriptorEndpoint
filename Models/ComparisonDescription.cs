namespace FluentValidationDescriptorEndpoint.Models
{
    public class ComparisonDescription
    {
        public string Type { get; set; }
        public object Value { get; set; }
        public string OtherMember { get; set; }
    }
}
