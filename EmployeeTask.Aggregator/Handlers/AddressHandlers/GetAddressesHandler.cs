using EmployeeTask.Aggregator.Queries.AddressQueries;
using EmployeeTask.Aggregator.ServiceContracts;
using MediatR;
using SharedModels.DTO.AddressDTO;

namespace EmployeeTask.Aggregator.Handlers.AddressHandlers
{
    public class GetAddressesHandler : IRequestHandler<GetAddressesQuery, IEnumerable<AddressResponse>>
    {
        private readonly IAddressesService _addressesService;

        public GetAddressesHandler(IAddressesService addressesService)
        {
            _addressesService = addressesService;
        }

        public async Task<IEnumerable<AddressResponse>> Handle(GetAddressesQuery request, CancellationToken cancellationToken)
        {
            // Get All Addresses from database
            IEnumerable<AddressResponse>? addresses = await _addressesService.GetAllAddresses();

            if (addresses is null)
                return new List<AddressResponse>();
            return addresses;
        }
    }
}
