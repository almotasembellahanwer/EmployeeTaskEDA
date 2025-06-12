namespace SharedModels.RabbitMQEvents.AreaEvents
{
    public interface IAreaCreatedEvent
    {
        public int AreaID { get; set; }
        public string? ArabicName { get; set; }
        public string? EnglishName { get; set; }
        public int GovernorateID { get; set; }
    }
}
