using FluentValidation;
using SharedModels.DTO.AddressDTO;
namespace SharedModels.Validators
{
    public class AddressAddRequestValidator :AddressBaseValidator<AddressAddRequest>
    {
        public AddressAddRequestValidator()
        {
            ValidateAddressName(temp => temp.AddressName!);
        }
    }
}
