using EmployeeTask.AccountService.DistrictCommands;
using EmployeeTask.AccountService.ServiceContracts;
using MassTransit;
using MediatR;
using SharedModels.DTO.DistrictDTO;
using SharedModels.RabbitMQEvents.AreaEvents;
using SharedModels.RabbitMQEvents.DistrictEvents;

namespace EmployeeTask.AccountService.Handlers.DistrictHandlers
{
    public class AddDistrictHandler : IRequestHandler<AddDistrictCommand, DistrictResponse>
    {
        private readonly IDistrictsService _districtsService;
        private readonly IPublishEndpoint _publishEndpoint;

        public AddDistrictHandler(IDistrictsService districtsService, IPublishEndpoint publishEndpoint)
        {
            _districtsService = districtsService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<DistrictResponse> Handle(AddDistrictCommand request, CancellationToken cancellationToken)
        {
            DistrictResponse? districtResponse = await _districtsService.AddDistrict(request.DistrictDTO);
            if (districtResponse is not null)
            {
                // Publish the event to rabbitmq
                await _publishEndpoint.Publish<IDistrictCreatedEvent>(new
                {
                    districtResponse.DistrictID,
                    districtResponse.ArabicName,
                    districtResponse.EnglishName,
                    districtResponse.AreaID
                });
            }
            return districtResponse ?? throw new InvalidOperationException("Error while adding a district");
        }
    }
}
