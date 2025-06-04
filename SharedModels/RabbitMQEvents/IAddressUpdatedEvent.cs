using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.RabbitMQEvents
{
    public interface IAddressUpdatedEvent
    {
        public int AddressID { get; set; }
        public string? NewAddressName { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
