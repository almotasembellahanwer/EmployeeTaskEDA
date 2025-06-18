using EmployeeTask.Aggregator.Entities;
using SharedModels.DTO.DepartmentDTO;

namespace EmployeeTask.Aggregator.Extensions
{
    public static class DepartmentQueryExtensions
    {
        public static IQueryable<Department> ApplySearch(this IQueryable<Department> query, DepartmentSearchRequest searchRequest)
        {
            if (searchRequest is null)
                return query;
            if (searchRequest.DepartmentID > 0)
                query = query.Where(d => d.DepartmentID == searchRequest.DepartmentID);
            if (!string.IsNullOrWhiteSpace(searchRequest.DepartmentName))
                query = query.Where(d => d.DepartmentName.ToLower().Contains(searchRequest.DepartmentName.ToLower()));
            return query;
        }
    }
}
