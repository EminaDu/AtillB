using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtillB.Models
{
    public class Note
    {
            public string value { get; set; }
            public string key { get; set; }
            public string type { get; set; }
            public int routeIdxFrom { get; set; }
            public int routeIdxTo { get; set; }
            public string txtN { get; set; }
        
    }
}
