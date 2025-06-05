using System.Net;

namespace EmployeeTask.AccountService.Entities;
public class Employee
{
    public int EmployeeID { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public int? AddressID { get; set; }
    public Address Address { get; set; } = default!;
}
