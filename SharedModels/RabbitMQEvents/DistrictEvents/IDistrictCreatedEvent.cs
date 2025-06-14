namespace SharedModels.RabbitMQEvents.DistrictEvents
{
    public interface IDistrictCreatedEvent
    {
        public int DistrictID { get; set; }
        public string? ArabicName { get; set; }
        public string? EnglishName { get; set; }
        public int AreaID { get; set; }
    }
}
