using EmployeeTask.AccountService.Entities;
using EmployeeTask.AccountService.RepositoryContracts;
using EmployeeTask.AccountService.ServiceContracts;
using Mapster;
using SharedModels.DTO.AreaDTO;

namespace EmployeeTask.AccountService.Services
{
    public class AreasService : IAreasService
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IGovernorateRepository _governorateRepository;


        public AreasService(IAreaRepository areaRepository, IGovernorateRepository governorateRepository)
        {
            _areaRepository = areaRepository;
            _governorateRepository = governorateRepository;
        }
        public async Task<AreaResponse?> AddArea(AreaAddRequest? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid area to add");
            Area area = entity.Adapt<Area>();
            Area? areaAdded = await _areaRepository.AddArea(area);
            if (areaAdded is null)
                throw new ArgumentException("error while adding area");
            AreaResponse response = areaAdded.Adapt<AreaResponse>();
            return response;
        }
        public async Task<AreaResponse?> UpdateArea(AreaUpdateRequest? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid area to add");
            Area area = entity.Adapt<Area>();
            Area? areaUpdated = await _areaRepository.UpdateArea(area);
            if (areaUpdated is null)
                throw new ArgumentException("error while updating area");
            AreaResponse response = areaUpdated.Adapt<AreaResponse>();
            return response;
        }
        public async Task<bool> DeleteArea(int areaID)
        {
            if (areaID == 0)
                throw new ArgumentException("Invalid ID");
            bool isDeleted = await _areaRepository.DeleteArea(areaID);
            return isDeleted;
        }
    }
}
