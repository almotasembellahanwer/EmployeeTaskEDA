using EmployeeTask.Aggregator.Queries.AddressQueries;
using EmployeeTask.Aggregator.Queries.AreaQueries;
using EmployeeTask.Aggregator.Queries.GovernorateQueries;
using EmployeeTask.Aggregator.ServiceContracts;
using MediatR;
using SharedModels.DTO.AddressDTO;
using SharedModels.DTO.AreaDTO;
using SharedModels.DTO.GovernorateDTO;

namespace EmployeeTask.Aggregator.Handlers.AreaHandlers
{
    public class GetAreasHandler : IRequestHandler<GetAreasQuery, IEnumerable<AreaResponse>>
    {
        private readonly IAreasService _areasService;

        public GetAreasHandler(IAreasService areasService)
        {
            _areasService = areasService;
        }

        public async Task<IEnumerable<AreaResponse>> Handle(GetAreasQuery request, CancellationToken cancellationToken)
        {
            // Get All Areas from database
            IEnumerable<AreaResponse>? areas = await _areasService.GetAllAreas();
            
            if (areas is null)
                return new List<AreaResponse>();
            return areas;
        }
    }
}
