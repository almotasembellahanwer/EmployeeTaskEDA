using EmployeeTask.Aggregator.Entities;

namespace EmployeeTask.Aggregator.IRepositoryContracts
{
    public interface IGovernorateRepository
    {
        Task<IEnumerable<Governorate>?> GetAllGovernorates();
        Task<Governorate?> GetGovernorateByID(int governorateID);
        Task<Governorate?> AddGovernorate(Governorate? entity);
        Task<Governorate?> UpdateGovernorate(Governorate? entity);
        Task<bool> DeleteGovernorate(int governorateID);
    }
}
