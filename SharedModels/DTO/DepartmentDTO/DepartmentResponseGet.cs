namespace SharedModels.DTO.DepartmentDTO;
public class DepartmentResponseGet()
{
    public int DepartmentID { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }


}
