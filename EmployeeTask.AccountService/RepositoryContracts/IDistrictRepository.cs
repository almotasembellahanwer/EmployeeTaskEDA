using EmployeeTask.AccountService.Entities;

namespace EmployeeTask.AccountService.RepositoryContracts
{
    public interface IDistrictRepository
    {
        Task<District?> AddDistrict(District? entity);
        Task<District?> UpdateDistrict(District? entity);
        Task<bool> DeleteDistrict(int districtID);
    }
}
