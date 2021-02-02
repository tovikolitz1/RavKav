using BLL.ModelDTO;
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
        public int id { get; set; }
        public List<TravelsDTO> TravelToCon { get; set; }
        public bool isFreeDay { get; set; }
        public string contractName { get; set; }
        public int contractID { get; set; }
        public double price { get; set; }
        public CalculateResulte(List<TravelsDTO> travelToCon, bool isFreeDay, string contractName, int contractID, double price)
        {
            this.TravelToCon = travelToCon;
            this.isFreeDay = isFreeDay;
            this.contractID = contractID;
            this.price = price;
            this.contractName = contractName;
        }
    }
}
