using EmployeeTask.Aggregator.Entities;
using SharedModels.DTO.AreaDTO;

namespace EmployeeTask.Aggregator.IRepositoryContracts
{
    public interface IAreaRepository
    {
        Task<IEnumerable<AreaResponseGet>?> GetAllAreas();
        Task<AreaResponseGet?> GetAreaByID(int areaID);
        Task<Area?> AddArea(Area? entity);
        Task<Area?> UpdateArea(Area? entity);
        Task<bool> DeleteArea(int areaID);
    }
}
