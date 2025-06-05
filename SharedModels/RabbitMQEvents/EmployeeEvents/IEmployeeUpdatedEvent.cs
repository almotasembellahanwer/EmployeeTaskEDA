using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.RabbitMQEvents.EmployeeEvents
{
    public interface IEmployeeUpdatedEvent
    {
        public int EmployeeID { get; set; }
        public string? NewEmployeeName { get; set; }
        public int? AddressID { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
