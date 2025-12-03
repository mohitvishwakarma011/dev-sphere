using DS.Core.Dto.Category;

namespace DS.Api.Validators.Category
{
    public class CategoryValidator:AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull();
            RuleFor(c=>c.Description).NotEmpty().NotNull();
        }
    }
}
