using EmployeeTask.Aggregator.Entities;
using EmployeeTask.Aggregator.IRepositoryContracts;
using EmployeeTask.Aggregator.ServiceContracts;
using Mapster;
using SharedModels.DTO.AreaDTO;
namespace EmployeeTask.Aggregator.Services
{
    public class AreasService : IAreasService
    {
        private readonly IAreaRepository _areaRepository;

        public AreasService(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public async Task<IEnumerable<AreaResponseGet>?> GetAllAreas()
        {
            IEnumerable<AreaResponseGet>? response = await _areaRepository.GetAllAreas();
            if (response is null)
                return new List<AreaResponseGet>();
            return response;
        }

        public async Task<AreaResponseGet?> GetAreaByID(int areaID)
        {
            if (areaID == 0)
                throw new ArgumentException("Invalid ID");
            AreaResponseGet? area = await _areaRepository.GetAreaByID(areaID);
            if (area is null)
                return null;
            return area;
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
