using EmployeeTask.AccountService.Entities;

namespace EmployeeTask.AccountService.RepositoryContracts
{
    public interface IAddressRepository
    {
        Task<Address?> AddAddress(Address? entity);
        Task<Address?> UpdateAddress(Address? entity);
        Task<bool> DeleteAddress(int addressID);
    }
}
