using SharedModels.DTO.AddressDTO;
using SharedModels.DTO.GovernorateDTO;

namespace EmployeeTask.Aggregator.ServiceContracts
{
    public interface IGovernoratesService
    {
        Task<IEnumerable<GovernorateResponse>?> GetAllGovernorates();
        Task<GovernorateResponse?> GetGovernorateByID(int governorateID);
        Task<GovernorateResponse?> AddGovernorate(GovernorateAddRequest? entity);
        Task<GovernorateResponse?> UpdateGovernorate(GovernorateUpdateRequest? entity);
        Task<bool> DeleteGovernorate(int governorateID);
    }
}
