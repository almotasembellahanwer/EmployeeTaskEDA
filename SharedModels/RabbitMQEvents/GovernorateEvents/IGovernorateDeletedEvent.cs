namespace SharedModels.RabbitMQEvents.GovernorateEvents
{
    public interface IGovernorateDeletedEvent
    {
        public int GovernorateID { get; set; }
        public DateTime DeletedAt { get; set; }

    }
}
