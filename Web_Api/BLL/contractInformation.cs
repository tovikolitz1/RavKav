using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ContractInformation
    {

       public int id { get; set; }
       public bool isContract { get; set; }
       public int idContractOrTravel { get; set; }
       public double price { get; set; }
        //constractor
        public ContractInformation(int idContractOrTravel, double price, bool isContract)
        {
            this.isContract = isContract;
            this.price = price;
            this.idContractOrTravel = idContractOrTravel;
        }

    }
}

