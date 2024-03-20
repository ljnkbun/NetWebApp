using Application.Commands.Users;
using Domain.Interfaces;
using FluentValidation;

namespace Application.Validations.Users
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandValidator(IUserRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.UserName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Password)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");


            RuleFor(p => p.Email)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 50 characters.")
               .EmailAddress().WithMessage("{PropertyName} must be email format.");

            RuleFor(p => p.PhoneNum)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.")
               .Matches(@"^\+?[0-9]{3,20}$").WithMessage("{PropertyName} must be phone number format.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            _repository = repository;
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _repository.IsUniqueAsync(code);
        }
    }
}
