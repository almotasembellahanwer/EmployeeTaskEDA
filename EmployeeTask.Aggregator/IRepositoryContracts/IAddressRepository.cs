using EmployeeTask.Aggregator.Entities;

namespace EmployeeTask.Aggregator.IRepositoryContracts
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>?> GetAllAddresses();
        Task<Address?> GetAddressByID(int addressID);
        Task<Address?> AddAddress(Address? entity);
        Task<Address?> UpdateAddress(Address? entity);
        Task<bool> DeleteAddress(int addressID);
    }
}
