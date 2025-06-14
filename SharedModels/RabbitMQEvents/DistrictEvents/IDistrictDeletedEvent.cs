namespace SharedModels.RabbitMQEvents.DistrictEvents
{
    public interface IDistrictDeletedEvent
    {
        public int DistrictID { get; set; }
        public DateTime DeletedAt { get; set; }

    }
}
