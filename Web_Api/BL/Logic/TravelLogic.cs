using BL.ModelDTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Logic
{
    class TravelLogic
    {
        static RavKav db = new RavKav();
        static List<Travel> travelsById = new List<Travel>();
        //dictionary of contracts' with their own areas
        static IDictionary<int, List<Area>> contractUsed = new Dictionary<int, List<Area>>();
        static List<Contract> contracts = new List<Contract>();
        public static void GetTravelsByIdAndMonth(int id, DateTime time)
        {
            //שליפה של כל החודש לפי שנה למשתמש מסוים
            travelsById = db.Travels.Where(x => x.userID == id && x.date.Year == time.Year && x.date.Month == time.Month)
                .OrderBy(x => x.price).ThenByDescending(x => x.areaID).ToList();
            //שליפה של כל החוזים שמתאימים לנסיעות של המשתמש
            contracts = db.Contracts.Where(x => x.AreaToContracts.Any(m => m.Area.Travels.Any(f => (f.userID == id && f.date.Year == time.Year && f.date.Month == time.Month)))).ToList();
            for (int i = 0; i < 28; i++)
            {
                contractBase(contracts.Where(x => x.AreaToContracts.Any(m => m.Area.Travels.Any(f => (f.userID == id && f.date.Year == time.Year && f.date.Month == time.Month && f.date.Day == i)))).ToList(), travelsById.Where(x => x.date.Day == i).ToList());
            }

        }
        //להוסיף לדיקנשרי של החוזים שבחרנו בהם את הנסיעות שלא נכנסו באף חוזה 


        //find base contract
        //the rule of base contract is:
        //contract who as Travel back and forth
        //With at least one more internal trip
        public static void contractBase(List<Contract> contracts, List<Travel> travelsById)
        {
            IDictionary<Travel, int> travelUsed = new Dictionary<Travel, int>();
            int cnt = 0;
            List<Travel> travelsToCurrentContract;
            //Go over the travel list for the user
            for (int i = 0; i < travelsById.Count; i++)
            {
                //Go over the travel list for the user
                if (travelsById[i].areaID == travelsById[i + 1].areaID)
                {
                     //Finding the the travels in a right and cheapest contract
                    travelsToCurrentContract = GetTravelOfCheapestContract(travelsById[i]);

                    foreach (var item in travelsToCurrentContract)
                    {
                        //Check if some of the trips have already been realized in other contracts
                        if (!travelUsed.ContainsKey(item))
                            cnt++;
                    }
                    //Check that there are more than three trips that have not been realized in any contract
                    if (cnt >= 3)
                    {
                        //Add the travels to the travels list that for them a contract has been found
                        foreach (var item in travelsToCurrentContract)
                        {
                            if (!travelUsed.ContainsKey(item))
                                travelUsed.Add(item, 0);
                        }
                    }
                }
            }

        }


        public static List<Travel> GetTravelOfCheapestContract(Travel currentTravel)
        {
            //Finding the right and cheapest contract
            var currentContractID = currentTravel.Area.AreaToContracts.OrderBy
                                    (x => x.Contract.freeDay).FirstOrDefault().id;

            //Pulling out all travel appropriate to the contract
            var travelsToCurrentContract = travelsById.Where(x => x.Area.AreaToContracts.Any
                                            (m => m.contractID == currentContractID)).ToList();

            return  travelsToCurrentContract;
        }


        public static void contractExtention(List<Contract> contracts, List<Travel> travelsById)
        {
            
            for (int i = 0; i < contractUsed.Count() - 1; i++)
            {
                int extntionContract;
                List<Area> areaI1 = contractUsed.ElementAt(i).Value;
                List<Area> areaI2 = contractUsed.ElementAt(i + 1).Value;

                extntionContract = contracts.Select(x => x.AreaToContracts.Join
                 (areaI1, AreaToCon1 => AreaToCon1.areaID, AreI1 => AreI1.id, (AreaToCon1, AreI1) => new { AreaToCon1, AreI1 }).Join
                 (areaI2, AreaToCon2 => AreaToCon2.AreI1.id, AreI2 => AreI2.id, (AreaToCon2, AreI2) => new { AreaToCon2, AreI2 })
                 .OrderBy(f => f.AreaToCon2.AreaToCon1.Contract.freeDay).FirstOrDefault().AreaToCon2.AreaToCon1.contractID).FirstOrDefault();
            }
            addTravelsToTheExtentionContract(extntionContract);
        }


        public static int findcontractExtentionOfToSmallContracts(int index)
        {
           int extntionContract = 0;
           List<Area> areaI1 = contractUsed.ElementAt(index).Value;
           List<Area> areaI2 = contractUsed.ElementAt(index + 1).Value;

           extntionContract = contracts.Select(x => x.AreaToContracts.Join
           (areaI1, AreaToCon1 => AreaToCon1.areaID, AreI1 => AreI1.id, (AreaToCon1, AreI1) => new { AreaToCon1, AreI1 }).Join
           (areaI2, AreaToCon2 => AreaToCon2.AreI1.id, AreI2 => AreI2.id, (AreaToCon2, AreI2) => new { AreaToCon2, AreI2 })
           .OrderBy(f => f.AreaToCon2.AreaToCon1.Contract.freeDay).FirstOrDefault().AreaToCon2.AreaToCon1.contractID).FirstOrDefault();

           return extntionContract;
        }
        

        public static void addTravelsToTheExtentionContract(int extntionContract)
        {
            if( extntionContract != 0)
            { }
        }

    }//  ולסמן עוד חוזים או נסיעות שיכלות להכלל בתוכו

}
