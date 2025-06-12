using SharedModels.DTO.AreaDTO;
namespace EmployeeTask.AccountService.ServiceContracts
{
    public interface IAreasService
    {
        Task<AreaResponse?> AddArea(AreaAddRequest? entity);
        Task<AreaResponse?> UpdateArea(AreaUpdateRequest? entity);
        Task<bool> DeleteArea(int areaID);
    }
}
