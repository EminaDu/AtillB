using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtillB.Models
{
    public class Departure
    {   
            public Journeydetailref JourneyDetailRef { get; set; }
            public string JourneyStatus { get; set; }
            public Productatstop ProductAtStop { get; set; }
            public Product[] Product { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string stop { get; set; }
            public string stopid { get; set; }
            public string stopExtId { get; set; }
            public string time { get; set; }
            public string date { get; set; }
            public bool reachable { get; set; }
            public string direction { get; set; }
            public string directionFlag { get; set; }
            public Notes Notes { get; set; }       
    }
}
