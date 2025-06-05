using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.RabbitMQEvents.EmployeeEvents
{
    public interface IEmployeeCreatedEvent
    {
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
    }
}
