using FluentValidation;

namespace jwt_token.DTOs.Validators
{
    public class AddUserDTOValidator : AbstractValidator<AddUserDTO>
    {
        public AddUserDTOValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(2).MaximumLength(20);
            RuleFor(x => x.Role).NotEmpty().MinimumLength(2).MaximumLength(20);
        }
    }
}
