namespace SharedModels.RabbitMQEvents.DepartmentEvents
{
    public interface IDepartmentUpdatedEvent
    {
        public int DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
