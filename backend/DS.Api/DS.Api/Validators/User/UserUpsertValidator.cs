
namespace DS.Api.Validators.User
{
    public class UserUpsertValidator: AbstractValidator<UserModel>
    {
        public UserUpsertValidator()
        {
            RuleFor(u => u.UserName)
                .NotEmpty()
                .WithMessage("UserName is cannot be empty")
                .Length(2,256)
                .WithMessage("UserName should be between 2 and 256 in Length.");

            RuleFor(u => u.UserEmail)
                .NotEmpty()
                .WithMessage("UserEmail is cannot be empty")
                .Length(2, 256)
                .WithMessage("UserEmail should be between 2 and 256 in Length.");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Password is cannot be empty");

            //Validation for role has been left intensionally
        }
    }
}
