using BLL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
       public List<TravelsDTO> travelsToContract { get; set; }
        //constractor
        public ContractInformation(int idContractOrTravel, double price, bool isContract, [Optional] List<TravelsDTO> travelsToContract)
        {
            this.isContract = isContract;
            this.price = price;
            this.idContractOrTravel = idContractOrTravel;
            if(travelsToContract !=null )
                this.travelsToContract = travelsToContract;
        }

    }
}

