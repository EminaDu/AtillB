using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtillB.Models
{
    
    public class Departures
    {
        public Departure[] Departure { get; set; }
        public Technicalmessages TechnicalMessages { get; set; }
        public string serverVersion { get; set; }
        public string dialectVersion { get; set; }
        public DateTime planRtTs { get; set; }
        public string requestId { get; set; }
    }
}