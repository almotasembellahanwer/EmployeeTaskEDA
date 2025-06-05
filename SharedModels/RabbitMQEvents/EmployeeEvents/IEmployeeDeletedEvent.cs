using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.RabbitMQEvents.EmployeeEvents
{
    public interface IEmployeeDeletedEvent
    {
        public int EmployeeID { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
