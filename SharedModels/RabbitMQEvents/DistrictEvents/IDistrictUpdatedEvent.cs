namespace SharedModels.RabbitMQEvents.DistrictEvents
{
    public interface IDistrictUpdatedEvent
    {
        public int DistrictID { get; set; }
        public string? ArabicName { get; set; }
        public string? EnglishName { get; set; }
        public int AreaID { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
