using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtillB.Models
{
    public class StopLocation
    { 
            public Productatstop[] productAtStop { get; set; }
            public int timezoneOffset { get; set; }
            public string id { get; set; }
            public string extId { get; set; }
            public string name { get; set; }
            public float lon { get; set; }
            public float lat { get; set; }
            public int weight { get; set; }
            public int dist { get; set; }
            public int products { get; set; }
    }
}
