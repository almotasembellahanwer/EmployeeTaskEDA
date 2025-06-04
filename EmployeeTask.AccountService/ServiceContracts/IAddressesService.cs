using SharedModels.DTO.AddressDTO;

namespace EmployeeTask.AccountService.ServiceContracts
{
    public interface IAddressesService
    {
        Task<AddressResponse?> AddAddress(AddressAddRequest? entity);
        Task<AddressResponse?> UpdateAddress(AddressUpdateRequest? entity);
        Task<bool> DeleteAddress(int addressID);
    }
}
