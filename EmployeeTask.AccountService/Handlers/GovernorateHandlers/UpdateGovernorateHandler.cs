using EmployeeTask.AccountService.GovernorateCommands;
using EmployeeTask.AccountService.ServiceContracts;
using MassTransit;
using MediatR;
using SharedModels.DTO.GovernorateDTO;

namespace EmployeeTask.AccountService.Handlers.GovernorateHandlers
{
    public class UpdateGovernorateHandler : IRequestHandler<UpdateGovernorateCommand, GovernorateResponse>
    {
        private readonly IGovernoratesService _governoratesService;
        private readonly IPublishEndpoint _publishEndpoint;

        public UpdateGovernorateHandler(IGovernoratesService governoratesService, IPublishEndpoint publishEndpoint)
        {
            _governoratesService = governoratesService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<GovernorateResponse> Handle(UpdateGovernorateCommand request, CancellationToken cancellationToken)
        {
            GovernorateResponse? governorateResponse = await _governoratesService.UpdateGovernorate(request.GovernorateDTO);
            //if (addressResponse is not null)
            //{
            //    // Publish the event for update to rabbitmq
            //    await _publishEndpoint.Publish<IAddressUpdatedEvent>(new
            //    {
            //        addressResponse.AddressID,
            //        NewAddressName = addressResponse.AddressName,
            //        UpdatedAt = DateTime.UtcNow
            //    });
            //}
            return governorateResponse ?? throw new InvalidOperationException("Error while adding an governorate");
        }
    }
}
