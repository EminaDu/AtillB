using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AtillB.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public int FreeSeats{ get; set; }
        public string From  { get; set; }
        public string To  { get; set; }
        public string Date   { get; set; }
    //public override string ToString()
    //{
    //    return "From: " +From+" To: "+To+" \n Leave time: "+Date +" Seats available: " + FreeSeats.ToString();
    //}
    }
}
