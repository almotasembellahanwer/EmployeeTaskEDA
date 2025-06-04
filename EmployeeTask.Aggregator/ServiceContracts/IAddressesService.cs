using SharedModels.DTO.AddressDTO;

namespace EmployeeTask.Aggregator.ServiceContracts
{
    public interface IAddressesService
    {
        Task<IEnumerable<AddressResponse>?> GetAllAddresses();
        Task<AddressResponse?> GetAddressByID(int addressID);
        Task<AddressResponse?> AddAddress(AddressAddRequest? entity);
        Task<AddressResponse?> UpdateAddress(AddressUpdateRequest? entity);
        Task<bool> DeleteAddress(int addressID);
    }
}
