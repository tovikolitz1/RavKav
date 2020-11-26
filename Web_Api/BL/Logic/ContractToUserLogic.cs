using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Logic
{
    class ContractToUserLogic
    {
        //להוסיף טבחלת חוזה למשתמש וDTO
        public static bool AddContract(contractsDTO con)
        {

            static RavKav db = new RavKav();
            contractToUser c = Convertions.Convertion(con);
            try
            {
                db.Users.Add(c);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
}
