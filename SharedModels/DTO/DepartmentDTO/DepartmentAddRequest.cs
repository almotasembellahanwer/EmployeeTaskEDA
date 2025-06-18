namespace SharedModels.DTO.DepartmentDTO;
public class DepartmentAddRequest
{
    public string DepartmentName { get; set; } = string.Empty;
    public bool Active { get; set; }
}
