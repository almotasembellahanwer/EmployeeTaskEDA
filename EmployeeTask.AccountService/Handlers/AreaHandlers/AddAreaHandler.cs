using EmployeeTask.AccountService.AreaCommands;
using EmployeeTask.AccountService.GovernorateCommands;
using EmployeeTask.AccountService.ServiceContracts;
using MassTransit;
using MediatR;
using SharedModels.DTO.AreaDTO;
using SharedModels.DTO.GovernorateDTO;
using SharedModels.RabbitMQEvents.AreaEvents;
using SharedModels.RabbitMQEvents.GovernorateEvents;

namespace EmployeeTask.AccountService.Handlers.AreaHandlers
{
    public class AddAreaHandler : IRequestHandler<AddAreaCommand, AreaResponse>
    {
        private readonly IAreasService _areasService;
        private readonly IPublishEndpoint _publishEndpoint;

        public AddAreaHandler(IAreasService areasService, IPublishEndpoint publishEndpoint)
        {
            _areasService = areasService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<AreaResponse> Handle(AddAreaCommand request, CancellationToken cancellationToken)
        {
            AreaResponse? areaResponse = await _areasService.AddArea(request.AreaDTO);
            if (areaResponse is not null)
            {
                // Publish the event to rabbitmq
                await _publishEndpoint.Publish<IAreaCreatedEvent>(new
                {
                    areaResponse.AreaID,
                    areaResponse.ArabicName,
                    areaResponse.EnglishName,
                    areaResponse.GovernorateID
                });
            }
            return areaResponse ?? throw new InvalidOperationException("Error while adding a area");
        }
    }
}
