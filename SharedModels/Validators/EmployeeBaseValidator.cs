using FluentValidation;
using System.Linq.Expressions;
namespace SharedModels.Validators
{
    public class EmployeeBaseValidator<T> : AbstractValidator<T>
    {
        protected IRuleBuilderOptions<T, string> ValidateEmployeeName(Expression<Func<T, string>> expression)
        {
            return RuleFor(expression)
              .NotEmpty()
              .WithMessage("Employee Name should not be blank")
              .MaximumLength(30)
              .WithMessage("Employee Name should not be greater than 30 character");
        }
    }
}
