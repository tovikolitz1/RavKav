using System;

namespace BLL.ModelDTO
{
   public class TravelsDTO
    {
        public int id { get; set; }
        public string buss { get; set; }
        public double price { get; set; }
        public int areaID { get; set; }
        public string areaName { get; set; }
        public bool trvelTrip { get; set; }
        public DateTime date { get; set; }
    }
}
