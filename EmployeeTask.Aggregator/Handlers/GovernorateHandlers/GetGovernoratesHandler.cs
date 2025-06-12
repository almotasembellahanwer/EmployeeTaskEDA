using EmployeeTask.Aggregator.Queries.AddressQueries;
using EmployeeTask.Aggregator.Queries.GovernorateQueries;
using EmployeeTask.Aggregator.ServiceContracts;
using MediatR;
using SharedModels.DTO.AddressDTO;
using SharedModels.DTO.GovernorateDTO;

namespace EmployeeTask.Aggregator.Handlers.GovernorateHandlers
{
    public class GetGovernoratesHandler : IRequestHandler<GetGovernoratesQuery, IEnumerable<GovernorateResponse>>
    {
        private readonly IGovernoratesService _governoratesService;

        public GetGovernoratesHandler(IGovernoratesService governoratesService)
        {
            _governoratesService = governoratesService;
        }

        public async Task<IEnumerable<GovernorateResponse>> Handle(GetGovernoratesQuery request, CancellationToken cancellationToken)
        {
            // Get All Governorates from database
            IEnumerable<GovernorateResponse>? governorates = await _governoratesService.GetAllGovernorates();
            
            if (governorates is null)
                return new List<GovernorateResponse>();
            return governorates;
        }
    }
}
