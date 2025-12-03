using DS.Core.Dto.Category;

namespace DS.Api.Validators.Category
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull();
            RuleFor(c => c.Description).NotEmpty().NotNull();
            RuleFor(c => c.Id).GreaterThan(0).WithMessage("Invalid category id");
        }
    }
}
