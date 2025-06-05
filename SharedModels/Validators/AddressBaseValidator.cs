using FluentValidation;
using System.Linq.Expressions;

namespace SharedModels.Validators
{
    public class AddressBaseValidator<T> : AbstractValidator<T>
    {
        protected IRuleBuilderOptions<T, string> ValidateAddressName(Expression<Func<T, string>> expression)
        {
            return RuleFor(expression)
              .NotEmpty()
              .WithMessage("Address Name should not be blank")
              .MaximumLength(70)
              .WithMessage("Address Name should not be greater than 70 character");
        }
    }
}
