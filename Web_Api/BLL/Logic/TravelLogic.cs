using DALL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Logic
{
    public static class TravelLogic
    {
        static RavKavEntities db = new RavKavEntities();
        static List<Travel> travelsById = new List<Travel>();
        static int currentContractID;
        //Dictionary of contracts, with their own areas
        static IDictionary<contractExtentionHelp, List<Area>> contractUsed = new Dictionary<contractExtentionHelp, List<Area>>();

        static List<Contract> contracts = new List<Contract>();
        //     public static 
        public static int CalaulateThePayment(int id, DateTime date)
        {
            GetTravelsByIdAndMonth(id, date);

            return 0;
        }
        public static void GetTravelsByIdAndMonth(int id, DateTime date)
        {
            //שליפה של כל החודש לפי שנה למשתמש מסוים

            //The travels for a particular user 
            travelsById = db.Travels.Where(x => x.userID == id &&
                                            x.date.Year == date.Year &&
                                            x.date.Month == date.Month)
                         .OrderBy(x => x.price).ThenByDescending(x => x.areaID).ToList();

            //שליפה של כל החוזים שמתאימים לנסיעות של המשתמש
            contracts = db.Contracts.Where(x => x.AreaToContracts.Any(m => m.Area.Travels.Any(f =>
            (f.userID == id && f.date.Year == date.Year && f.date.Month == date.Month)))).ToList();
            for (int i = 0; i < DateTime.DaysInMonth(date.Year, date.Month); i++)
            {
                ContractBase(contracts.Where(x => x.AreaToContracts.Any(m => m.Area.Travels.Any
                (f => (f.userID == id && f.date.Year == date.Year && f.date.Month == date.Month && f.date.Day == i)))).ToList()
                , travelsById.Where(x => x.date.Day == i).ToList());
            }

        }

        //find base contract
        //the rule of base contract is:
        //contract who as Travel back and forth
        //With at least one more internal trip
        public static void ContractBase(List<Contract> contracts, List<Travel> travelsById)
        {
            //Dictionary of used travels
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
                        //add the current contract to dictionary contractUsed
                        contractUsed.Add(new contractExtentionHelp(currentContractID,
                               contracts.Where(x => x.id == currentContractID).FirstOrDefault().freeDay, true),
                               db.Areas.Where(x => x.AreaToContracts.Any(m => m.contractID == currentContractID)).ToList());
                        //Add the travels to the travels list that for them a contract has been found
                        foreach (var item in travelsToCurrentContract)
                        {
                            if (!travelUsed.ContainsKey(item))
                                travelUsed.Add(item, 0);
                        }
                    }
                }
            }
            //add signal travels to contract used dictionary
            foreach (var travel in travelsById)
            {
                if (!travelUsed.ContainsKey(travel))

                    contractUsed.Add(new contractExtentionHelp(travel.id, travel.price, false), new List<Area>(travel.areaID));
            }


        }


        public static List<Travel> GetTravelOfCheapestContract(Travel currentTravel)
        {
            //Finding the right and cheapest contract
            currentContractID = currentTravel.Area.AreaToContracts.OrderBy(x => x.Contract.freeDay).FirstOrDefault().id;

            //Pulling out all travel appropriate to the contract
            var travelsToCurrentContract = travelsById.Where(x => x.Area.AreaToContracts.Any(m => m.contractID == currentContractID)).ToList();

            return travelsToCurrentContract;
        }


        public static void ContractExtention(List<Contract> contracts, List<Travel> travelsById)
        {
            Contract extntionContract;
            for (int i = 0; i < contractUsed.Count() - 1; i++)
            {
                for (int j = i+1; j < contractUsed.Count(); j++)
                {
                    extntionContract = FindContractExtentionOfTwoSmallContracts(i,j);
                    if (extntionContract != null)
                    {
                        if (AddTravelsToTheExtentionContract(extntionContract))
                        {
                            i = -1;
                            j = contractUsed.Count();
                        }
                        
                    }
                }
            }

        }


        public static Contract FindContractExtentionOfTwoSmallContracts(int indexI,int indexJ)
        {
            List<Area> areaI1 = contractUsed.ElementAt(indexI).Value;
            List<Area> areaI2 = contractUsed.ElementAt(indexJ).Value;

            //join with 3 tables
            var extntionContract = contracts.Select(x => x.AreaToContracts.Join
             (areaI1, AreaToCon1 => AreaToCon1.areaID, AreI1 => AreI1.id, (AreaToCon1, AreI1) => new { AreaToCon1, AreI1 }).Join
             (areaI2, AreaToCon2 => AreaToCon2.AreI1.id, AreI2 => AreI2.id, (AreaToCon2, AreI2) => new { AreaToCon2, AreI2 })
             .OrderBy(f => f.AreaToCon2.AreaToCon1.Contract.freeDay).FirstOrDefault().AreaToCon2.AreaToCon1.Contract).FirstOrDefault();

            return extntionContract;
        }


        public static bool AddTravelsToTheExtentionContract(Contract extntionContract)
        {
            bool response = false;
            List<Area> areaToCurrentContractTemp = new List<Area>();
            double sumOfTravelPrice = 0;
            foreach (var item in contractUsed)
            {
                if (contracts.Select(x => x.AreaToContracts.Join
                    (item.Value, AreaToCon => AreaToCon.areaID, itemArea => itemArea.id, (AreaToCon, itemArea) => new { AreaToCon, itemArea })
                    .Where(y => y.AreaToCon.contractID == extntionContract.id)
                    ).Any())
                {
                    sumOfTravelPrice += item.Key.price;
                }
            }
            if (extntionContract.freeDay <= sumOfTravelPrice)
            {
                foreach (var item in contractUsed)
                {
                    if (contracts.Select(x => x.AreaToContracts.Join
                    (item.Value, AreaToCon => AreaToCon.areaID, itemArea => itemArea.id, (AreaToCon, itemArea) => new { AreaToCon, itemArea })
                    .Where(y => y.AreaToCon.contractID == extntionContract.id)
                    ).Any())
                    {
                        foreach (var area in item.Value)
                        {
                            areaToCurrentContractTemp.Add(area);
                        }
                        contractUsed.Remove(item);
                    }
                }
                contractUsed.Add(new contractExtentionHelp(extntionContract.id, extntionContract.freeDay, true), areaToCurrentContractTemp);
                response = true;
            }
            
            return response;
        }

    }

}
