using EmployeeTask.AccountService.Entities;
using EmployeeTask.AccountService.RepositoryContracts;
using EmployeeTask.AccountService.ServiceContracts;
using Mapster;
using SharedModels.DTO.AddressDTO;
using SharedModels.DTO.GovernorateDTO;

namespace EmployeeTask.AccountService.Services
{
    public class GovernoratesService : IGovernoratesService
    {
        private readonly IGovernorateRepository _governorateRepository;

        public GovernoratesService(IGovernorateRepository governorateRepository)
        {
            _governorateRepository = governorateRepository;
        }
        public async Task<GovernorateResponse?> AddGovernorate(GovernorateAddRequest? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid governorate to add");
            Governorate governorate = entity.Adapt<Governorate>();
            Governorate? governorateAdded = await _governorateRepository.AddGovernorate(governorate);
            if (governorateAdded is null)
                throw new ArgumentException("error while adding governorate");
            GovernorateResponse response = governorateAdded.Adapt<GovernorateResponse>();
            return response;
        }
        public async Task<GovernorateResponse?> UpdateGovernorate(GovernorateUpdateRequest? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid governorate to add");
            Governorate governorate = entity.Adapt<Governorate>();
            Governorate? governorateUpdated = await _governorateRepository.UpdateGovernorate(governorate);
            if (governorateUpdated is null)
                throw new ArgumentException("error while updating governorate");
            GovernorateResponse response = governorateUpdated.Adapt<GovernorateResponse>();
            return response;
        }
        public async Task<bool> DeleteGovernorate(int governorateID)
        {
            if (governorateID == 0)
                throw new ArgumentException("Invalid ID");
            bool isDeleted = await _governorateRepository.DeleteGovernorate(governorateID);
            return isDeleted;
        }
    }
}
