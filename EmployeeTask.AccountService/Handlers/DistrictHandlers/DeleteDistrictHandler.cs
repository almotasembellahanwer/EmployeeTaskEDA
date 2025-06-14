using EmployeeTask.AccountService.DistrictCommands;
using EmployeeTask.AccountService.ServiceContracts;
using MassTransit;
using MediatR;
using SharedModels.RabbitMQEvents.DistrictEvents;
namespace EmployeeTask.AccountService.Handlers.DistrictHandlers
{
    public class DeleteDistrictHandler : IRequestHandler<DeleteDistrictCommand, bool>
    {
        private readonly IDistrictsService _districtsService;
        private readonly IPublishEndpoint _publishEndpoint;

        public DeleteDistrictHandler(IDistrictsService districtsService, IPublishEndpoint publishEndpoint)
        {
            _districtsService = districtsService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<bool> Handle(DeleteDistrictCommand request, CancellationToken cancellationToken)
        {
            bool isDeleted = await _districtsService.DeleteDistrict(request.DistrictID);
            if (isDeleted)
            {
                // Publish the event to rabbitmq
                await _publishEndpoint.Publish<IDistrictDeletedEvent>(new
                {
                    request.DistrictID,
                    DeletedAt = DateTime.UtcNow
                });
            }
            return isDeleted;
        }
    }
}
