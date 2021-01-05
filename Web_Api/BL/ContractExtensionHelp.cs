using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class ContractExtensionHelp
    {
        int id { get; set; }
        bool isContract { get; set; }
        IDictionary<int, string> areas { get; set; }
        int idContractOrTravel { get; set; }
        double price { get; set; }
        //פעולה בונה לחוזה
        public ContractExtensionHelp(IDictionary<int, string> areas, int idContractOrTravel, double price)
        {
            isContract = true;
            this.areas = areas;
            this.idContractOrTravel = idContractOrTravel;
            this.price = price;
        }
        //פעולה בונה לנסיעה
        public ContractExtensionHelp(int areaID, int idContractOrTravel, double price)
        {
            isContract = false;
            areas.Add(areaID, "");
            this.idContractOrTravel = idContractOrTravel;
            this.price = price;
        }
    }
}
