using FluentValidation;
using SharedModels.DTO.EmployeeDTO;
namespace SharedModels.Validators
{
    public class EmployeeAddRequestValidator : EmployeeBaseValidator<EmployeeAddRequest>
    {
        public EmployeeAddRequestValidator()
        {
            ValidateEmployeeName(temp => temp.EmployeeName!);
        }
    }
}
