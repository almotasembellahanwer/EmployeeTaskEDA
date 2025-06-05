using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.RabbitMQEvents.AddressEvents
{
    public interface IAddressCreatedEvent
    {
        public int AddressID { get; set; }
        public string? AddressName { get; set; }
    }
}
