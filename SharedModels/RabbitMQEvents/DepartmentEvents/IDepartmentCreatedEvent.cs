namespace SharedModels.RabbitMQEvents.DepartmentEvents
{
    public interface IDepartmentCreatedEvent
    {
        public int DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
        public bool Active { get; set; }
    }
}
