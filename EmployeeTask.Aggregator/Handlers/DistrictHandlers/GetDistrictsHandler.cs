using EmployeeTask.Aggregator.Queries.DistrictQueries;
using EmployeeTask.Aggregator.ServiceContracts;
using MediatR;
using SharedModels.DTO.DistrictDTO;

namespace EmployeeTask.Aggregator.Handlers.DistrictHandlers
{
    public class GetDistrictsHandler : IRequestHandler<GetDistrictsQuery, IEnumerable<DistrictResponseGet>>
    {
        private readonly IDistrictsService _districtsService;

        public GetDistrictsHandler(IDistrictsService districtsService)
        {
            _districtsService = districtsService;
        }

        public async Task<IEnumerable<DistrictResponseGet>> Handle(GetDistrictsQuery request, CancellationToken cancellationToken)
        {
            // Get All Districts from database
            IEnumerable<DistrictResponseGet>? districts = await _districtsService.GetAllDistricts();
            
            if (districts is null)
                return new List<DistrictResponseGet>();
            return districts;
        }
    }
}
