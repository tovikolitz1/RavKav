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
        static Contract currentContract;
        static List<Area> areaToCurrentContractTemp;
        //Dictionary of contracts, with their own areas
        static IDictionary<contractExtentionHelp, List<Area>> contractUsed;
        static List<Contract> contracts = new List<Contract>();
        //     public static 
        public static int CalaulateThePayment(int id, DateTime date)
        {
            GetTravelsByIdAndMonth(id, date);

            return 0;
        }
        public static void GetTravelsByIdAndMonth(int id, DateTime date)
        {
            //The travels for a particular user 
            travelsById = db.Travels.Where(x => x.userID == id &&
                                            x.date.Year == date.Year &&
                                            x.date.Month == date.Month)
                         .OrderBy(x => x.price).ThenBy(x => x.areaID).ToList();

            //get all contracts appropriate to the user's travel
            contracts = db.Contracts.Where(x => x.AreaToContracts.Any(m => m.Area.Travels.Any(f =>
            (f.userID == id && f.date.Year == date.Year && f.date.Month == date.Month)))).ToList();
            //Sending travels by day and appropriate contracts for that day
            for (int i = 0; i < DateTime.DaysInMonth(date.Year, date.Month); i++)
            {
                ContractBase(contracts.Where(x => x.AreaToContracts.Any(m => m.Area.Travels.Any
                (f => (f.userID == id && f.date.Year == date.Year && f.date.Month == date.Month && f.date.Day == i)))).ToList()
                , travelsById.Where(x => x.date.Day == i).ToList());
                ContractExtention();

            }

        }

        //find base contract
        //the rule of base contract is:
        //contract who as Travel back and forth
        //With at least one more internal trip
        public static void ContractBase(List<Contract> contracts, List<Travel> travelsByDay)
        {
           contractUsed = new Dictionary<contractExtentionHelp, List<Area>>();
            //Dictionary of used travels
            IDictionary<Travel, int> travelUsed = new Dictionary<Travel, int>();

            double price = 0;
            List<Travel> travelsToCurrentContract;
            //Go over the travel list for the user
            for (int i = 0; i < travelsByDay.Count; i++)
            {
                if (travelUsed.ContainsKey(travelsByDay[i]))
                    continue;
                price = 0;
                //Finding the right and cheapest contract
                currentContract = travelsByDay[i].Area.AreaToContracts.OrderBy(x => x.Contract.freeDay).FirstOrDefault().Contract;

                //Pulling out all travel appropriate to the contract
                travelsToCurrentContract = travelsByDay.Where(x => x.Area.AreaToContracts.Any(m => m.contractID == currentContract.id)).ToList();
                foreach (var item in travelsToCurrentContract)
                {
                    //Check if some of the trips have already been realized in other contracts if not sum them price
                    if (!travelUsed.ContainsKey(item))
                        price += item.price;
                }
                if (currentContract.freeDay <= price)
                {
                    //add the current contract to dictionary contractUsed
                    // travelsByDay.Where(x=>x.Area
                    //  db.Areas.Where(x => x.AreaToContracts.Any(m => m.contractID == currentContract.id)).ToList());
                    areaToCurrentContractTemp = new List<Area>();
                    //Add the travels to the travels list that for them a contract has been found
                    foreach (var item in travelsToCurrentContract)
                    {
                        if (!travelUsed.ContainsKey(item))
                        {
                            areaToCurrentContractTemp.Add(item.Area);
                            travelUsed.Add(item, 0);
                        }
                    }
                    contractUsed.Add(new contractExtentionHelp(currentContract.id, currentContract.freeDay, true), areaToCurrentContractTemp);
                }

            }
            //add signal travels to contract used dictionary
            foreach (var travel in travelsByDay)
            {
                if (!travelUsed.ContainsKey(travel))
                    contractUsed.Add(new contractExtentionHelp(travel.id, travel.price, false), new List<Area>(travel.areaID));
            }
           
        }

        public static void ContractExtention()
        {
            Contract extntionContract;
            for (int i = 0; i < contractUsed.Count() - 1; i++)
            {
                for (int j = i + 1; j < contractUsed.Count(); j++)
                {
                    //send two contrecta to check if there is extantion contract for them
                    extntionContract = FindContractExtentionOfTwoSmallContracts(i, j);
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


        public static Contract FindContractExtentionOfTwoSmallContracts(int indexI, int indexJ)
        {
            List<Area> areaI1 = contractUsed.ElementAt(indexI).Value;
            List<Area> areaI2 = contractUsed.ElementAt(indexJ).Value;

            //join with 3 tables to find extention contract of two contracts
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
                //sum price of all contracts that include in the extention contract
                if (contracts.Select(x => x.AreaToContracts.Join
                    (item.Value, AreaToCon => AreaToCon.areaID, itemArea => itemArea.id, (AreaToCon, itemArea) => new { AreaToCon, itemArea })
                    .Where(y => y.AreaToCon.contractID == extntionContract.id)
                    ).Any())
                {//
                    sumOfTravelPrice += item.Key.price;
                }
            }
            //check if the extention contract is cheapest
            if (extntionContract.freeDay <= sumOfTravelPrice)
            {
                foreach (var item in contractUsed)
                {
                    if (contracts.Select(x => x.AreaToContracts.Join
                    (item.Value, AreaToCon => AreaToCon.areaID, itemArea => itemArea.id, (AreaToCon, itemArea) => new { AreaToCon, itemArea })
                    .Where(y => y.AreaToCon.contractID == extntionContract.id)
                    ).Any())
                    {
                        //add the areas of all contracts that include in the extention contract
                        foreach (var area in item.Value)
                        {
                            areaToCurrentContractTemp.Add(area);
                        }
                        //remove all contracts that include in the extention contract
                        contractUsed.Remove(item);
                    }
                }
                //add extention contract to contractUsed
                contractUsed.Add(new contractExtentionHelp(extntionContract.id, extntionContract.freeDay, true), areaToCurrentContractTemp);
                response = true;
            }
            //return true if ther is extention contract
            return response;
        }

    }

}
