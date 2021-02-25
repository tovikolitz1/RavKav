﻿

using BLL.ModelDTO;
using DALL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Logic
{
    public static class TravelLogic
    {
        #region declar
        static RavKavEntities db = new RavKavEntities();
        static List<Travel> travelsById = new List<Travel>();
        static List<Travel> travelsByDate = new List<Travel>();
        static Contract currentContract;
        static List<Area> areaToCurrentContractTemp;
        //Dictionary of contracts, with their own areas
        static IDictionary<ContractInformation, List<Area>> contractUsed = new Dictionary<ContractInformation, List<Area>>();
        static IDictionary<Travel, int> travelUsed = new Dictionary<Travel, int>();
        static List<Contract> contracts = new List<Contract>();
        static List<TravelsDTO> travelsToCurrentContractDTO;
        static string type;
        //   static List<Contract> contractsByDate = new List<Contract>();
        //contracts.Where(x => x.AreaToContracts.Any(m => m.Area.Travels.Any(f => (f.userID == id && f.date.Year == date.Year && f.date.Month == date.Month && f.date.Day == i)))).ToList()
        static List<CalculateResulte> calculateResultes = new List<CalculateResulte>();
        static int conid = 0;
        static double difference = 0;
        static Contract extntionContract = new Contract();
        #endregion
        public static List<CalculateResulte> CalaulateThePayment(int id, DateTime date)
        {

            travelUsed.Clear();
            calculateResultes.Clear();

            calculateResultes.Add(new CalculateResulte(new List<TravelsDTO>(), false, "נסיעות בודדות", 0, 0));
            GetTravelsAndContractsByIdAndMonth(id, date);
            //free month
            type = "freeMounth";
            travelsByDate = travelsById;
            if (travelsByDate.Count() == 0)
                return null;
            
            ContractBase(id);
            ContractExtention(id);
            addToCalculateResulte();
            //int w = 0;
            //while (contractUsed.Count() > w)
            //{
            //    if (contractUsed.ElementAt(w).Key.isContract == false)
            //        contractUsed.Remove(contractUsed.ElementAt(w));
            //    else
            //        w++;
            //}
            contractUsed.Clear();

            //free day
            //Sending travels by day and appropriate contracts for that day
            type = "freeDay";

            for (int i = 0; i < DateTime.DaysInMonth(date.Year, date.Month); i++)
            {
                travelUsed.Clear();
                travelsByDate = travelsById.Where(x => x.date.Day == i).ToList();
                if (travelsByDate.Count() == 0) continue;
                ContractBase(id);
                ContractExtention(id);
                addToCalculateResulte();
            }
            //  double signalTravelsPrice = 0;
            //List<TravelsDTO> t = new List<TravelsDTO>();
            //foreach (var travel in travelsById)
            //{
            //    if (!travelUsed.ContainsKey(travel))
            //    {
            //        signalTravelsPrice += travel.price;
            //        t.Add(Convertions.Convertion(travel));
            //    }
            //}

            //CalculateResulte c = new CalculateResulte(t, type == "freeDay" ? true : false, "נסיעה בודדת", 0, signalTravelsPrice);
            if (calculateResultes[0].price == 0)
                calculateResultes.Remove(calculateResultes[0]);
           // calculateResultes.Add(c);
            return calculateResultes;
        }
        public static void GetTravelsAndContractsByIdAndMonth(int id, DateTime date)
        {

            //The travels for a particular user 
            travelsById = db.Travels.Where(x => x.userID == id &&
                                            x.date.Year == date.Year &&
                                            x.date.Month == date.Month)
                         .OrderBy(x => x.price).ThenBy(x => x.areaID).ToList();

            //get all contracts whom may appropriate to the user's travels
            contracts = db.Contracts.Where(x => x.AreaToContracts.Any(m => m.Area.Travels.Any(f =>
            f.userID == id && f.date.Year == date.Year && f.date.Month == date.Month))).ToList();
        }
        //find base contract
        //the rules of base contract are:
        //contract who as the area of current travel 
        //and this contract is cheapest cheapest
        public static void ContractBase(int id)
        {
            //contractUsed = new Dictionary<ContractInformation, List<Area>>();
            int contractTemp = -1;
            //Dictionary of used travels
            var profile = db.Profiles.Where(b => b.Users.Any(c => c.id == id)).FirstOrDefault();
            double profileDiscount = 0;
            if (profile != null)
            {
                profileDiscount = Convert.ToDouble(profile.discount);
            }
            double price = 0;
            List<Travel> travelsToCurrentContract;
            AreaToContract areaToCurrentContract;

            //Go over the travel list for the user
            for (int i = 0; i < travelsByDate.Count; i++)
            {

                if (travelUsed.ContainsKey(travelsByDate[i]))
                    continue;
                price = 0;
                //Finding the right and cheapest contract

                areaToCurrentContract = travelsByDate[i].Area.AreaToContracts.
                    OrderBy(x => (type == "freeDay" ? x.Contract.freeDay : x.Contract.freeMounth)).FirstOrDefault();
                
                if (areaToCurrentContract != null)
                {
                    currentContract = areaToCurrentContract.Contract;

                }
                if (currentContract.id == contractTemp)
                    continue;
                contractTemp = currentContract.id;
                //Pulling out all travel appropriate to the contract
                travelsToCurrentContract = travelsByDate.Where(x => x.Area.AreaToContracts.Any(m => m.contractID == currentContract.id)).ToList();
                foreach (var item in travelsToCurrentContract)
                {
                    //Check if some of the travels have already been realized in other contracts, if not sum them price
                    if (!travelUsed.ContainsKey(item))
                        price += item.price;
                }
                if ((type == "freeDay" ? currentContract.freeDay : currentContract.freeMounth) <= price * profileDiscount)

                {
                    areaToCurrentContractTemp = new List<Area>();
                    travelsToCurrentContractDTO = new List<TravelsDTO>();
                    //Add the travels to the travelUsed that for them a contract has been found
                    foreach (var item in travelsToCurrentContract)
                    {
                        if (!travelUsed.ContainsKey(item))
                        {
                            areaToCurrentContractTemp.Add(item.Area);
                            travelUsed.Add(item, currentContract.id);
                            travelsToCurrentContractDTO.Add(Convertions.Convertion(item));
                        }
                    }
                    //add the current contract to dictionary contractUsed
                    contractUsed.Add(new ContractInformation(currentContract.id,
                        (type == "freeDay" ? currentContract.freeDay : currentContract.freeMounth), true, travelsToCurrentContractDTO), areaToCurrentContractTemp);
                }

            }

            //add signal travels to contract used dictionary
            foreach (var travel in travelsByDate)
            {
                if (!travelUsed.ContainsKey(travel))
                {
                    List<Area> listSignalArea = new List<Area>();
                    listSignalArea.Add(travel.Area);
                    contractUsed.Add(new ContractInformation(travel.id, travel.price, false), listSignalArea);
                }
            }

        }

        public static void ContractExtention(int id)
        {
            bool b = func(id);
            while (b)
            {
                ContractInformation con;
                foreach (var c in contractUsed)
                {
                    if (contracts.Select(x => x.AreaToContracts.Join(c.Value, AreaToCon => AreaToCon.areaID, itemArea => itemArea.id, (AreaToCon, itemArea) => new { AreaToCon, itemArea }).Where(y => y.AreaToCon.contractID == conid)).Any())
                    {//create list of areas thet include in the extation contract
                        foreach (var area in c.Value)
                        {
                            areaToCurrentContractTemp.Add(area);
                        }
                        //adding a single travel that included in the extantion contract to travelUsed
                        if (c.Key.isContract == false)
                        {
                            var g = travelsById.Where(x => x.id == c.Key.idContractOrTravel).FirstOrDefault();
                            if (g != null)
                                travelUsed.Add(g, conid);
                            //remove contracts and single travels that in the the extantion contract
                            contractUsed.Remove(c);
                        }
                    }
                    foreach (var t in travelUsed)
                    { //changing the contract code for travels that were included in the contract that extaned
                        Contract g = contracts.Where(m => m.id == t.Value).FirstOrDefault();
                        ContractInformation a = null;
                        if (g != null)
                            a = new ContractInformation(t.Value, (type == "freeDay" ? g.freeDay : g.freeMounth), true);
                        if (!contractUsed.ContainsKey(a))
                            travelUsed[t.Key] = conid;
                        travelsToCurrentContractDTO.Add(Convertions.Convertion(t.Key));
                    }
                    //add extation contract to contractUsed
                    con = new ContractInformation(conid, (type == "freeDay" ? extntionContract.freeDay : extntionContract.freeMounth), true, travelsToCurrentContractDTO);
                    contractUsed.Add(con, areaToCurrentContractTemp);
                    b = func(id);
                }
                string day = travelsByDate[0].date.Day.ToString();
                //create a travel list for each contract
                foreach (var contract in contractUsed)
                {
                    if (contract.Key.isContract == false)
                        continue;
                    List<TravelsDTO> t = new List<TravelsDTO>();
                    if (type == "freeMounth")
                    {

                        foreach (var travel in travelUsed)
                        {
                            if (travel.Value == contract.Key.id)
                                t.Add(Convertions.Convertion(travel.Key));
                        }
                    }
                    else
                    {
                        foreach (var travel in travelUsed)
                        {
                            if (travel.Value == contract.Key.id && travel.Key.date.Day.ToString() == day)
                                t.Add(Convertions.Convertion(travel.Key));
                        }
                    }
                    CalculateResulte conresult;
                    var d = contracts.Where(x => x.id == contract.Key.id).FirstOrDefault().Description;
                    if (d != null)
                    {
                        conresult = new CalculateResulte(t, type == "freeDay" ? true : false, d, contract.Key.id, contract.Key.price);
                        calculateResultes.Add(conresult);
                    }
                }
            }


        }

        /* public static IEnumerable<object> FullJoin(   IEnumerable<Area> first, IEnumerable<Area> second)
         {
            var d=first.Join(first,second=>)
         }
            */

            //find contract whos containing two small contracts
        public static Contract FindContractExtentionOfTwoSmallContracts(int indexI, int indexJ)
        {
            List<Area> areaI1 = new List<Area>();
            foreach (var item in contractUsed.ElementAt(indexI).Value)
            {
                areaI1.Add(item);
            }
            foreach (var item in contractUsed.ElementAt(indexJ).Value)
            {
                areaI1.Add(item);
            }
            areaI1 = areaI1.Distinct().ToList();

            try
            {
                var conID = contracts.ToList().Select(x =>
                x.AreaToContracts.Where(f => areaI1.Contains(f.Area))
                .OrderBy(a => type == "freeDay" ? a.Contract.freeDay : a.Contract.freeMounth)
                .GroupBy(g => g.contractID)
                .Where(sd => sd.Count() == areaI1.Count())
                .Select(k => k.Key).ToList())
                .Where(x => x.Count() == 1).FirstOrDefault();
                 return extntionContract;
            }
            catch (Exception x)
            {
                return null;
            }
        }

        public static bool func(int id)
        {
            var profileDiscount = Convert.ToDouble(db.Profiles.Where(b => b.Users.Any(c => c.id == id)).FirstOrDefault().discount);
            conid = 0;
            difference = 0;
            extntionContract = null;
            double sumOfTravelPrice = 0;
            int areaTemp = -1;
            int areaTempJ = -1;
            for (int i = 0; i < contractUsed.Count() - 1; i++)
            {
                //check if contract already has been checked (only fot signals travels)
                if (contractUsed.ElementAt(i).Key.isContract == false && contractUsed.ElementAt(i).Value[0].id == areaTemp)
                    continue;
                areaTemp = contractUsed.ElementAt(i).Value[0].id;
                for (int j = i + 1; j < contractUsed.Count(); j++)
                {//chek if two signal travels have same area (To prevent duplicate testing)
                    if (contractUsed.ElementAt(i).Key.isContract == false && (contractUsed.ElementAt(j).Key.isContract == false && contractUsed.ElementAt(i).Value[0].id == contractUsed.ElementAt(j).Value[0].id || contractUsed.ElementAt(j).Value[0].id == areaTempJ))
                        continue;
                    areaTempJ = contractUsed.ElementAt(j).Value[0].id;
                    //send two contract to check if there is extantion contract for them
                    extntionContract = FindContractExtentionOfTwoSmallContracts(i, j);
                    if (extntionContract != null)
                    {
                        //create area list of extention contract
                        List<Area> l = db.AreaToContracts.Where(r => r.contractID == extntionContract.id).Select(h => h.Area).ToList();
                        foreach (var item in contractUsed)
                        {
                            //check if contract include in the extention contract
                            List<Area> a = l.Intersect(item.Value).ToList();
                            //sum price of all contracts that include in the extention contract
                            if (a.Count() == item.Value.Count())
                            {
                                sumOfTravelPrice += item.Key.price;
                            }
                        }
                        ///check if the extention contract is cheapest
                        if ((type == "freeDay" ? extntionContract.freeDay : extntionContract.freeMounth) <= sumOfTravelPrice * profileDiscount && sumOfTravelPrice * profileDiscount - (type == "freeDay" ? extntionContract.freeDay : extntionContract.freeMounth) > difference)
                        {
                            conid = extntionContract.id;
                            difference = sumOfTravelPrice - (type == "freeDay" ? extntionContract.freeDay : extntionContract.freeMounth);
                        }
                    }
                }
            }
            if (conid == 0 && difference == 0)
                return false;
            else
                return true;
        }
        public static void addToCalculateResulte()
        {
            Contract con3;
            foreach (var item in contractUsed)
            {

                if (item.Key.isContract == true)
                {
                    con3 = contracts.Where(u => u.id == item.Key.idContractOrTravel).FirstOrDefault();
                    if (con3 != null)
                    {
                        CalculateResulte c = new CalculateResulte(travelsToCurrentContractDTO, type == "freeDay" ? true : false,con3.Description, item.Key.idContractOrTravel,item.Key.price);
                        calculateResultes.Add(c);
                    }
                }
                else
                {
                    if (type == "freeDay")
                    {
                        Travel tr = db.Travels.Where(q => q.id == item.Key.idContractOrTravel).FirstOrDefault();
                        if (tr != null)
                        {
                            TravelsDTO trDTO = Convertions.Convertion(tr);
                            calculateResultes[0].TravelToCon.Add(trDTO);
                            calculateResultes[0].price += item.Key.price;
                        }
                    }
                }
            }
        }
    }

}


