using FluentValidation;
using SharedModels.DTO.AddressDTO;
namespace SharedModels.Validators
{
    public class AddressUpdateRequestValidator : AddressBaseValidator<AddressUpdateRequest>
    {
        public AddressUpdateRequestValidator()
        {
            RuleFor(temp => temp.AddressID)
                .NotEmpty()
                .WithMessage("Address ID should not be blank");
            ValidateAddressName(temp => temp.AddressName!);
        }
    }
}
