using SharedModels.DTO.DistrictDTO;
namespace EmployeeTask.AccountService.ServiceContracts
{
    public interface IDistrictsService
    {
        Task<DistrictResponse?> AddDistrict(DistrictAddRequest? entity);
        Task<DistrictResponse?> UpdateDistrict(DistrictUpdateRequest? entity);
        Task<bool> DeleteDistrict(int districtID);
    }
}
