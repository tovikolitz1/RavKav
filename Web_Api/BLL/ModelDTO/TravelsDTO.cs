using System;

namespace BLL.ModelDTO
{
    class TravelsDTO
    {
        public int id { get; set; }
        public string buss { get; set; }
        public double price { get; set; }
        public int areaID { get; set; }
        public int areaName { get; set; }
        public bool internalOrIntermediate { get; set; }
        public bool trvelTrip { get; set; }
        public int userID { get; set; }
        public string userName { get; set; }
        public DateTime date { get; set; }
    }
}
