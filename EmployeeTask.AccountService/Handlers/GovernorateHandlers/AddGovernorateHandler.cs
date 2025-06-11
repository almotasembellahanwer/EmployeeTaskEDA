using EmployeeTask.AccountService.GovernorateCommands;
using EmployeeTask.AccountService.ServiceContracts;
using MassTransit;
using MediatR;
using SharedModels.DTO.GovernorateDTO;

namespace EmployeeTask.AccountService.Handlers.GovernorateHandlers
{
    public class AddGovernorateHandler : IRequestHandler<AddGovernorateCommand, GovernorateResponse>
    {
        private readonly IGovernoratesService _governoratesService;
        private readonly IPublishEndpoint _publishEndpoint;

        public AddGovernorateHandler(IGovernoratesService governoratesService, IPublishEndpoint publishEndpoint)
        {
            _governoratesService = governoratesService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<GovernorateResponse> Handle(AddGovernorateCommand request, CancellationToken cancellationToken)
        {
            GovernorateResponse? governorateResponse = await _governoratesService.AddGovernorate(request.GovernorateDTO);
            //if (governorateResponse is not null)
            //{
            //    // Publish the event to rabbitmq
            //    await _publishEndpoint.Publish<IAddressCreatedEvent>(new
            //    {
            //        addressResponse.AddressID,
            //        addressResponse.AddressName
            //    });
            //}
            return governorateResponse ?? throw new InvalidOperationException("Error while adding a governorate");
        }
    }
}
