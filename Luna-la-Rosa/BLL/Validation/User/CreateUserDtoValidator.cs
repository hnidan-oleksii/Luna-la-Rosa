using BLL.DTO.User;
using FluentValidation;

namespace BLL.Validation.User
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.PasswordHash)
                .NotEmpty().WithMessage("Password is required.");

            RuleFor(x => x.FirstName) 
                .Matches(@"^[a-zA-Z]+$").WithMessage("Invalid first name format.") 
                .When(x => !string.IsNullOrEmpty(x.FirstName)); 
            
            RuleFor(x => x.LastName) 
                .Matches(@"^[a-zA-Z]+$").WithMessage("Invalid last name format.") 
                .When(x => !string.IsNullOrEmpty(x.LastName));

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.")
                .When(x => !string.IsNullOrEmpty(x.PhoneNumber));
        }
    }
}