using DALL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CalculateResulte
    {
        public Contract con { get; set; }
        public List<Travel> travelToCon { get; set; }
        public bool isFreeDay { get; set; }
        public CalculateResulte(Contract con, List<Travel> travelToCon, bool isFreeDay)
        {
            this.con = con;
            this.travelToCon = travelToCon;
            this.isFreeDay = isFreeDay;
        }
    }
}
