namespace SharedModels.DTO.DepartmentDTO;
public record DepartmentUpdateRequest(int DepartmentID, string DepartmentName, bool Active, DateTime CreatedAt);
