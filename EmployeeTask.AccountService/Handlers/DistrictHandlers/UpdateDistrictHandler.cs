using EmployeeTask.AccountService.DistrictCommands;
using EmployeeTask.AccountService.ServiceContracts;
using MassTransit;
using MediatR;
using SharedModels.DTO.DistrictDTO;
using SharedModels.RabbitMQEvents.DistrictEvents;

namespace EmployeeTask.AccountService.Handlers.DistrictHandlers
{
    public class UpdateDistrictHandler : IRequestHandler<UpdateDistrictCommand, DistrictResponse>
    {
        private readonly IDistrictsService _districtsService;
        private readonly IPublishEndpoint _publishEndpoint;

        public UpdateDistrictHandler(IDistrictsService districtsService, IPublishEndpoint publishEndpoint)
        {
            _districtsService = districtsService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<DistrictResponse> Handle(UpdateDistrictCommand request, CancellationToken cancellationToken)
        {
            DistrictResponse? districtResponse = await _districtsService.UpdateDistrict(request.DistrictDTO);
            if (districtResponse is not null)
            {
                // Publish the event for update to rabbitmq
                await _publishEndpoint.Publish<IDistrictUpdatedEvent>(new
                {
                    districtResponse.ArabicName,
                    districtResponse.EnglishName,
                    districtResponse.AreaID,
                    UpdatedAt = DateTime.UtcNow
                });
            }
            return districtResponse ?? throw new InvalidOperationException("Error while adding an district");
        }
    }
}
