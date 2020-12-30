using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ModelDTO
{
    class TravelsDTO
    {
        public int id { get; set; }
        public string buss { get; set; }
        public double price { get; set; }
        public int areaID { get; set; }
        public bool internalOrIntermediate { get; set; }
        public bool trvelTrip { get; set; }
        public int userID { get; set; }
        public DateTime date { get; set; }
        //שדה שלא קיים בDB
        public bool used { get; set; }
    }
}
