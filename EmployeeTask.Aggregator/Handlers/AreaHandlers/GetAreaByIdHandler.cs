using EmployeeTask.Aggregator.Queries.AreaQueries;
using EmployeeTask.Aggregator.Queries.GovernorateQueries;
using EmployeeTask.Aggregator.ServiceContracts;
using MediatR;
using SharedModels.DTO.AreaDTO;
using SharedModels.DTO.GovernorateDTO;

namespace EmployeeTask.Aggregator.Handlers.GovernorateHandlers
{
    public class GetAreaByIdHandler : IRequestHandler<GetAreaByIdQuery, AreaResponse?>
    {
        private readonly IAreasService _areasService;

        public GetAreaByIdHandler(IAreasService areasService) => _areasService = areasService;

        public async Task<AreaResponse?> Handle(GetAreaByIdQuery request, CancellationToken cancellationToken)
        {
            AreaResponse? area = await _areasService.GetAreaByID(request.Id);
            if (area is null)
                return null;
            return area;
        }
    }
}
