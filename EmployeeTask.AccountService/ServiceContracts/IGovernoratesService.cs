using SharedModels.DTO.GovernorateDTO;

namespace EmployeeTask.AccountService.ServiceContracts
{
    public interface IGovernoratesService
    {
        Task<GovernorateResponse?> AddGovernorate(GovernorateAddRequest? entity);
        Task<GovernorateResponse?> UpdateGovernorate(GovernorateUpdateRequest? entity);
        Task<bool> DeleteGovernorate(int governorateID);
    }
}
