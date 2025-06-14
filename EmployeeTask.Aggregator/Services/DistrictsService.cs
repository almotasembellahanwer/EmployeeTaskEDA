using EmployeeTask.Aggregator.Entities;
using EmployeeTask.Aggregator.IRepositoryContracts;
using EmployeeTask.Aggregator.ServiceContracts;
using Mapster;
using SharedModels.DTO.DistrictDTO;
namespace EmployeeTask.Aggregator.Services
{
    public class DistrictsService : IDistrictsService
    {
        private readonly IDistrictRepository _districtRepository;

        public DistrictsService(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public async Task<IEnumerable<DistrictResponseGet>?> GetAllDistricts()
        {
            IEnumerable<DistrictResponseGet>? response = await _districtRepository.GetAllDistricts();
            if (response is null)
                return new List<DistrictResponseGet>();
            return response;
        }

        public async Task<DistrictResponseGet?> GetDistrictByID(int districtID)
        {
            if (districtID == 0)
                throw new ArgumentException("Invalid ID");
            DistrictResponseGet? district = await _districtRepository.GetDistrictByID(districtID);
            if (district is null)
                return null;
            return district;
        }
        public async Task<DistrictResponse?> AddDistrict(DistrictAddRequest? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid district to add");
            District district = entity.Adapt<District>();
            District? districtAdded = await _districtRepository.AddDistrict(district);
            if (districtAdded is null)
                throw new ArgumentException("error while adding district");
            DistrictResponse response = districtAdded.Adapt<DistrictResponse>();
            return response;
        }
        public async Task<DistrictResponse?> UpdateDistrict(DistrictUpdateRequest? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid district to add");
            District district = entity.Adapt<District>();
            District? districtUpdated = await _districtRepository.UpdateDistrict(district);
            if (districtUpdated is null)
                throw new ArgumentException("error while updating district");
            DistrictResponse response = districtUpdated.Adapt<DistrictResponse>();
            return response;
        }
        public async Task<bool> DeleteDistrict(int districtID)
        {
            if (districtID == 0)
                throw new ArgumentException("Invalid ID");
            bool isDeleted = await _districtRepository.DeleteDistrict(districtID);
            return isDeleted;
        }
    }
}
