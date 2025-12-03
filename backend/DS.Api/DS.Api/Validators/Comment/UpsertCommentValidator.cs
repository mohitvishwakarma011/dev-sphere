using DS.Core.Dto.Comment;

namespace DS.Api.Validators.Comment
{
    public class UpsertCommentValidator : AbstractValidator<UpsertCommentDto>
    {
        public UpsertCommentValidator()
        {
            RuleFor(c => c.Content).NotEmpty();
            RuleFor(c => c.PostId).GreaterThan(0).WithMessage("PostId is required");
        }
    }
}
