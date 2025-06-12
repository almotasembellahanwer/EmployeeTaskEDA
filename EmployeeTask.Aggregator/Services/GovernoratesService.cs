using EmployeeTask.Aggregator.Entities;
using EmployeeTask.Aggregator.IRepositoryContracts;
using EmployeeTask.Aggregator.ServiceContracts;
using Mapster;
using SharedModels.DTO.GovernorateDTO;

namespace EmployeeTask.Aggregator.Services
{
    public class GovernoratesService : IGovernoratesService
    {
        private readonly IGovernorateRepository _governorateRepository;

        public GovernoratesService(IGovernorateRepository governorateRepository)
        {
            _governorateRepository = governorateRepository;
        }

        public async Task<IEnumerable<GovernorateResponse>?> GetAllGovernorates()
        {
            IEnumerable<Governorate>? governorates = await _governorateRepository.GetAllGovernorates();
            if (governorates is null)
                return new List<GovernorateResponse>();
            IEnumerable<GovernorateResponse> response = governorates.Adapt<IEnumerable<GovernorateResponse>>();
            return response;
        }

        public async Task<GovernorateResponse?> GetGovernorateByID(int governorateID)
        {
            if (governorateID == 0)
                throw new ArgumentException("Invalid ID");
            Governorate? governorate = await _governorateRepository.GetGovernorateByID(governorateID);
            if (governorate is null)
                return null;
            GovernorateResponse response = governorate.Adapt<GovernorateResponse>();
            return response;
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
