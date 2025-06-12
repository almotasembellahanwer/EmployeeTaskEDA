using EmployeeTask.Aggregator.Entities;

namespace EmployeeTask.Aggregator.IRepositoryContracts
{
    public interface IAreaRepository
    {
        Task<IEnumerable<Area>?> GetAllAreas();
        Task<Area?> GetAreaByID(int areaID);
        Task<Area?> AddArea(Area? entity);
        Task<Area?> UpdateArea(Area? entity);
        Task<bool> DeleteArea(int areaID);
    }
}
