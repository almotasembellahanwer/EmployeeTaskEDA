using EmployeeTask.AccountService.Entities;
using EmployeeTask.AccountService.RepositoryContracts;
using EmployeeTask.AccountService.ServiceContracts;
using Mapster;
using SharedModels.DTO.DepartmentDTO;

namespace EmployeeTask.AccountService.Services
{
    public class DepartmentsService : IDepartmentsService
    {
        private readonly IDepartmentRepository _departmentRepository;


        public DepartmentsService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<DepartmentResponse?> AddDepartment(DepartmentAddRequest? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid department to add");
            Department department = entity.Adapt<Department>();
            Department? departmentAdded = await _departmentRepository.AddDepartment(department);
            if (departmentAdded is null)
                throw new ArgumentException("error while adding department");
            DepartmentResponse response = departmentAdded.Adapt<DepartmentResponse>();
            return response;
        }
        public async Task<DepartmentResponse?> UpdateDepartment(DepartmentUpdateRequest? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid department to add");
            Department department = entity.Adapt<Department>();
            Department? departmentUpdated = await _departmentRepository.UpdateDepartment(department);
            if (departmentUpdated is null)
                throw new ArgumentException("error while updating department");
            DepartmentResponse response = departmentUpdated.Adapt<DepartmentResponse>();
            return response;
        }
        public async Task<bool> DeleteDepartment(int departmentID)
        {
            if (departmentID == 0)
                throw new ArgumentException("Invalid ID");
            bool isDeleted = await _departmentRepository.DeleteDepartment(departmentID);
            return isDeleted;
        }
    }
}
