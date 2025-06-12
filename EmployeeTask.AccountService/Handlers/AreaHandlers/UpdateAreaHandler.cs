using EmployeeTask.AccountService.AreaCommands;
using EmployeeTask.AccountService.ServiceContracts;
using MassTransit;
using MediatR;
using SharedModels.DTO.AreaDTO;
using SharedModels.RabbitMQEvents.AreaEvents;

namespace EmployeeTask.AccountService.Handlers.AreaHandlers
{
    public class UpdateAreaHandler : IRequestHandler<UpdateAreaCommand, AreaResponse>
    {
        private readonly IAreasService _areasService;
        private readonly IPublishEndpoint _publishEndpoint;

        public UpdateAreaHandler(IAreasService areasService, IPublishEndpoint publishEndpoint)
        {
            _areasService = areasService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<AreaResponse> Handle(UpdateAreaCommand request, CancellationToken cancellationToken)
        {
            AreaResponse? areaResponse = await _areasService.UpdateArea(request.AreaDTO);
            if (areaResponse is not null)
            {
                // Publish the event for update to rabbitmq
                await _publishEndpoint.Publish<IAreaUpdatedEvent>(new
                {
                    areaResponse.ArabicName,
                    areaResponse.EnglishName,
                    areaResponse.GovernorateID,
                    UpdatedAt = DateTime.UtcNow
                });
            }
            return areaResponse ?? throw new InvalidOperationException("Error while adding an area");
        }
    }
}
