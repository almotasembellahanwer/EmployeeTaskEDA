namespace EmployeeTask.Aggregator.Entities
{
    public class Area
    {
        public int AreaID { get; set; }
        public string ArabicName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
        public int? GovernorateID { get; set; }
        public Governorate Governorate { get; set; } = default!;

    }
}
