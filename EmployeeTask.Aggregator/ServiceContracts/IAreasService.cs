using SharedModels.DTO.AddressDTO;
using SharedModels.DTO.AreaDTO;
using SharedModels.DTO.GovernorateDTO;

namespace EmployeeTask.Aggregator.ServiceContracts
{
    public interface IAreasService
    {
        Task<IEnumerable<AreaResponse>?> GetAllAreas();
        Task<AreaResponse?> GetAreaByID(int areaID);
        Task<AreaResponse?> AddArea(AreaAddRequest? entity);
        Task<AreaResponse?> UpdateArea(AreaUpdateRequest? entity);
        Task<bool> DeleteArea(int areaID);
    }
}
