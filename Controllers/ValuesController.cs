using System;
using System.Linq;
using FluentValidation;
using FluentValidationDescriptorEndpoint.Mappers;
using FluentValidationDescriptorEndpoint.Models;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationDescriptorEndpoint.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class ValuesController : Controller
    {
        private readonly IValidator<Value> _validator;
        private readonly ValidationDescriptionMapper _validationDescriptionMapper;

        public ValuesController(IValidator<Value> validator)
        {
            _validator = validator;
            _validationDescriptionMapper = new ValidationDescriptionMapper();
        }

        [HttpGet]
        [Route("[controller]")]
        public IActionResult Get()
        {
            return Ok(new[]
            {
                new Value { Id = Guid.NewGuid(), Name = "Value 1"}
            });
        }

        [HttpGet]
        [Route("[controller]/validationrules")]
        public IActionResult GetValidationRules()
        {
            return Ok(_validator.CreateDescriptor()
                .GetMembersWithValidators()
                .ToDictionary(
                    g => g.Key,
                    validators => validators.Select(_validationDescriptionMapper.Map)));
        }
    }
}
