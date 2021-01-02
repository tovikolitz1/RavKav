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
        Node<int> areas { get; set; }
        int idContractOrTravel { get; set; }
        //פעולה בונה לחוזה
        public ContractExtensionHelp(Node<int> areas,int idContractOrTravel)
        {
            isContract = true;
            this.areas = areas;
            this.idContractOrTravel = idContractOrTravel;
        }
        //פעולה בונה לנסיעה
        public ContractExtensionHelp(int areaID , int idContractOrTravel)
        {
            isContract = false;
            areas = new Node<int>(areaID);
            this.idContractOrTravel = idContractOrTravel;
        }
    }
}
