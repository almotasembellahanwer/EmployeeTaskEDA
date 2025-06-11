using EmployeeTask.AccountService.Entities;

namespace EmployeeTask.AccountService.RepositoryContracts
{
    public interface IGovernorateRepository
    {
        Task<Governorate?> AddGovernorate(Governorate? entity);
        Task<Governorate?> UpdateGovernorate(Governorate? entity);
        Task<bool> DeleteGovernorate(int governorateID);
    }
}
