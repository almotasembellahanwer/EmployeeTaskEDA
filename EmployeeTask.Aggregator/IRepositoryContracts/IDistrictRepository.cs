using EmployeeTask.Aggregator.Entities;
using SharedModels.DTO.DistrictDTO;

namespace EmployeeTask.Aggregator.IRepositoryContracts
{
    public interface IDistrictRepository
    {
        Task<IEnumerable<DistrictResponseGet>?> GetAllDistricts();
        Task<DistrictResponseGet?> GetDistrictByID(int districtID);
        Task<District?> AddDistrict(District? entity);
        Task<District?> UpdateDistrict(District? entity);
        Task<bool> DeleteDistrict(int districtID);
    }
}
