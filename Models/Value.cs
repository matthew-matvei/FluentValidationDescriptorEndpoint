using System;

namespace FluentValidationDescriptorEndpoint.Models
{
    public class Value
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
