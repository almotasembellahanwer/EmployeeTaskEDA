using EmployeeTask.Aggregator.Queries.GovernorateQueries;
using EmployeeTask.Aggregator.ServiceContracts;
using MediatR;
using SharedModels.DTO.GovernorateDTO;

namespace EmployeeTask.Aggregator.Handlers.GovernorateHandlers
{
    public class GetGovernorateByIdHandler : IRequestHandler<GetGovernorateByIdQuery, GovernorateResponse?>
    {
        private readonly IGovernoratesService _governoratesService;

        public GetGovernorateByIdHandler(IGovernoratesService governoratesService) => _governoratesService = governoratesService;

        public async Task<GovernorateResponse?> Handle(GetGovernorateByIdQuery request, CancellationToken cancellationToken)
        {
            GovernorateResponse? governorate = await _governoratesService.GetGovernorateByID(request.Id);
            if (governorate is null)
                return null;
            return governorate;
        }
    }
}
