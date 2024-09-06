using DevOps_Boards.Data.Dto;
using FluentValidation;

namespace DevOps_Boards.FluentValidation
{
	public class LoginValidation:AbstractValidator<LoginDto>
	{
        public LoginValidation()
        {
			RuleFor(user => user.Email).NotEmpty().NotNull().EmailAddress().When(user => user.Email != null);
			RuleFor(user => user.Password).NotNull().NotEmpty().MinimumLength(5);
		}
    }
}
