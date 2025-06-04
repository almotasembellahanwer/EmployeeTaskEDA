using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.RabbitMQEvents
{
    public interface IAddressDeletedEvent
    {
        public int AddressID { get; set; }
        public DateTime DeletedAt { get; set; }

    }
}
