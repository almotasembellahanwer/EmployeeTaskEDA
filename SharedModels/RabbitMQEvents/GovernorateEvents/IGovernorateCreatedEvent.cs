namespace SharedModels.RabbitMQEvents.GovernorateEvents
{
    public interface IGovernorateCreatedEvent
    {
        public int GovernorateID { get; set; }
        public string? ArabicName { get; set; }
        public string? EnglishName { get; set; }
    }
}
