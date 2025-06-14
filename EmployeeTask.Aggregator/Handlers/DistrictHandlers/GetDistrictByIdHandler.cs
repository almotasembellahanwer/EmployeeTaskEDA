using EmployeeTask.Aggregator.Queries.DistrictQueries;
using EmployeeTask.Aggregator.ServiceContracts;
using MediatR;
using SharedModels.DTO.DistrictDTO;

namespace EmployeeTask.Aggregator.Handlers.GovernorateHandlers
{
    public class GetDistrictByIdHandler : IRequestHandler<GetDistrictByIdQuery, DistrictResponseGet?>
    {
        private readonly IDistrictsService _districtsService;

        public GetDistrictByIdHandler(IDistrictsService districtsService) => _districtsService = districtsService;

        public async Task<DistrictResponseGet?> Handle(GetDistrictByIdQuery request, CancellationToken cancellationToken)
        {
            DistrictResponseGet? district = await _districtsService.GetDistrictByID(request.Id);
            if (district is null)
                return null;
            return district;
        }
    }
}
