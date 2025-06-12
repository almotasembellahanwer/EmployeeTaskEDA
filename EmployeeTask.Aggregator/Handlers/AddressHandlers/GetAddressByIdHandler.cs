using EmployeeTask.Aggregator.Queries.AddressQueries;
using EmployeeTask.Aggregator.ServiceContracts;
using MediatR;
using SharedModels.DTO.AddressDTO;
using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.Aggregator.Handlers.AddressHandlers
{
    public class GetAddressByIdHandler : IRequestHandler<GetAddressByIdQuery, AddressResponse?>
    {
        private readonly IAddressesService _addressesService;

        public GetAddressByIdHandler(IAddressesService addressesService) => _addressesService = addressesService;

        public async Task<AddressResponse?> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            AddressResponse? address = await _addressesService.GetAddressByID(request.Id);
            if (address is null)
                return null;
            return address;
        }
    }
}
