namespace DS.Api.Validators.Post
{
    public class PostValidator:AbstractValidator<PostModel>
    {
        public PostValidator() 
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Title is required.")
                .Length(2, 500)
                .WithMessage("Title must be greater than 2 and less than 2000 in length.");

            RuleFor(p => p.Content)
                .NotEmpty()
                .NotNull()
                .WithMessage("Content is required.");

            RuleFor(p => p.AuthorId)
                .GreaterThan(0)
                .WithMessage("AuthorId is required.");

            RuleFor(p => p.CategoryId)
               .GreaterThan(0)
               .WithMessage("CategoryId is required.");

            RuleFor(p => p.SubCategoryId)
               .GreaterThan(0)
               .WithMessage("SubCategoryId is required.");

        }
    }
}
