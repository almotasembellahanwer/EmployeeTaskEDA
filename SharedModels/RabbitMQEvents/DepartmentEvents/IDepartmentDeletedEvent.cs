namespace SharedModels.RabbitMQEvents.DepartmentEvents
{
    public interface IDepartmentDeletedEvent
    {
        public int DepartmentID { get; set; }
        public DateTime DeletedAt { get; set; }

    }
}
