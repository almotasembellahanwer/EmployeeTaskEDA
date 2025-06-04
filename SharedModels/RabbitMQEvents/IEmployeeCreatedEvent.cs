using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.RabbitMQEvents
{
    public interface IEmployeeCreatedEvent
    {
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public string? AddressName { get; set; }
    }
}
