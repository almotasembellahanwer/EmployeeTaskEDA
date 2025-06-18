namespace EmployeeTask.Aggregator.Entities
{
    public class Department
    {
        public int DepartmentID{ get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
