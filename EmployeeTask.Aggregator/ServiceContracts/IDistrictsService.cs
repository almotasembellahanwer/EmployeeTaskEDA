using SharedModels.DTO.DistrictDTO;
namespace EmployeeTask.Aggregator.ServiceContracts
{
    public interface IDistrictsService
    {
        Task<IEnumerable<DistrictResponseGet>?> GetAllDistricts();
        Task<DistrictResponseGet?> GetDistrictByID(int districtID);
        Task<DistrictResponse?> AddDistrict(DistrictAddRequest? entity);
        Task<DistrictResponse?> UpdateDistrict(DistrictUpdateRequest? entity);
        Task<bool> DeleteDistrict(int districtID);
    }
}
