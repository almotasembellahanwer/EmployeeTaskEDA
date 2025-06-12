namespace SharedModels.RabbitMQEvents.AreaEvents
{
    public interface IAreaDeletedEvent
    {
        public int AreaID { get; set; }
        public DateTime DeletedAt { get; set; }

    }
}
