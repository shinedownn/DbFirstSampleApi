using DbFirstSampleApi.Entities.EndpointParams.Product;
using FluentValidation;

namespace DbFirstSampleApi.Entities.Validations
{
    public class CreateProductParamsValidator : AbstractValidator<CreateProductParams>
    {
        public CreateProductParamsValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x=>x.Category).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x=>x.IsActive).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x=>x.Price).NotEmpty().WithMessage("Boş geçilemez");
        }
    }
}
