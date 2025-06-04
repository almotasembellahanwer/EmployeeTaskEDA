using EmployeeTask.Aggregator.Entities;
using EmployeeTask.Aggregator.IRepositoryContracts;
using EmployeeTask.Aggregator.ServiceContracts;
using Mapster;
using SharedModels.DTO.AddressDTO;

namespace EmployeeTask.Aggregator.Services
{
    public class AddressesService : IAddressesService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressesService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<AddressResponse>?> GetAllAddresses()
        {
            IEnumerable<Address>? addresses = await _addressRepository.GetAllAddresses();
            if (addresses is null)
                return new List<AddressResponse>();
            IEnumerable<AddressResponse> response = addresses.Adapt<IEnumerable<AddressResponse>>();
            return response;
        }

        public async Task<AddressResponse?> GetAddressByID(int addressID)
        {
            if (addressID == 0)
                throw new ArgumentException("Invalid ID");
            Address? address = await _addressRepository.GetAddressByID(addressID);
            if (address is null)
                return null;
            AddressResponse response = address.Adapt<AddressResponse>();
            return response;
        }
        public async Task<AddressResponse?> AddAddress(AddressAddRequest? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid address to add");
            Address address = entity.Adapt<Address>();
            Address? addressAdded = await _addressRepository.AddAddress(address);
            if (addressAdded is null)
                throw new ArgumentException("error while adding address");
            AddressResponse response = addressAdded.Adapt<AddressResponse>();
            return response;
        }
        public async Task<AddressResponse?> UpdateAddress(AddressUpdateRequest? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid address to add");
            Address address = entity.Adapt<Address>();
            Address? addressUpdated = await _addressRepository.UpdateAddress(address);
            if (addressUpdated is null)
                throw new ArgumentException("error while updating address");
            AddressResponse response = addressUpdated.Adapt<AddressResponse>();
            return response;
        }
        public async Task<bool> DeleteAddress(int addressID)
        {
            if (addressID == 0)
                throw new ArgumentException("Invalid ID");
            bool isDeleted = await _addressRepository.DeleteAddress(addressID);
            return isDeleted;
        }
    }
}
