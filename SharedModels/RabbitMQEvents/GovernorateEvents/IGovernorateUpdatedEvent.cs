using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.RabbitMQEvents.GovernorateEvents
{
    public interface IGovernorateUpdatedEvent
    {
        public int GovernorateID { get; set; }
        public string? ArabicName { get; set; }
        public string? EnglishName { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
