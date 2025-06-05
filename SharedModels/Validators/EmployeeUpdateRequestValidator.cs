using FluentValidation;
using SharedModels.DTO.EmployeeDTO;
namespace SharedModels.Validators
{
    public class EmployeeUpdateRequestValidator : EmployeeBaseValidator<EmployeeUpdateRequest>
    {
        public EmployeeUpdateRequestValidator()
        {
            RuleFor(temp => temp.EmployeeID)
                .NotEmpty()
                .WithMessage("Employee ID should not be blank");
            ValidateEmployeeName(temp => temp.EmployeeName!);
        }
    }
}
