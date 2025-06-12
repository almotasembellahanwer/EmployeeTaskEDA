using EmployeeTask.AccountService.Entities;

namespace EmployeeTask.AccountService.RepositoryContracts
{
    public interface IAreaRepository
    {
        Task<Area?> AddArea(Area? entity);
        Task<Area?> UpdateArea(Area? entity);
        Task<bool> DeleteArea(int areaID);
    }
}
