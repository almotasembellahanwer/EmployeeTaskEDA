namespace EmployeeTask.Aggregator.Entities
{
    public class District
    {
        public int DistrictID { get; set; }
        public string ArabicName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
        public int? AreaID { get; set; }
        public Area Area { get; set; } = default!;

    }
}
