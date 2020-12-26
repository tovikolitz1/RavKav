using BL.ModelDTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Logic
{
    public static class MyExtensions
    {

        public static T GetNext<T>(this List<T> list, T item)
        {
            int index = list.IndexOf(item);
            return list[index + 1];

        }
        public static T GetPrevious<T>(this List<T> list, T item)
        {
            int index = list.IndexOf(item);
            return list[index - 1];
        }
    }
    class TravelLogic
    {
        static RavKav db = new RavKav();
        public static List<TravelsDTO> GetTravelsById(int id)
        {
            //שליפת כל הנסיעות בצורה ממוינת לפי מחיר ואזור
            List<Travel> travelsById = new List<Travel>();
            travelsById = db.Travels.Where(x => x.id == id).OrderBy(x => x.price).ThenByDescending(x => x.areaID).ToList();
            List<Contract> contracts = new List<Contract>();
            contracts = db.Contracts.ToList();
            List<AreaToContract> areaToContracts = new List<AreaToContract>();
            areaToContracts = db.AreaToContracts.ToList();
            List<TravelsDTO> travelsByIdDTO = new List<TravelsDTO>();
            IDictionary<int, bool> areas = new Dictionary<int, bool>();
            foreach (var item in travelsById)
            {//יצירת דיקשנרי של כל האזורים הקיימים למשתמש זה
                travelsByIdDTO.Add(Convertions.Convertion(item));
                if (!areas.ContainsKey(item.areaID))
                {
                    areas.Add(item.areaID, false);
                }
            }
            //מעבר על רשימת הנסיעות ומציאת חוזה לשתי נסיעות זהות
            foreach (var item in travelsByIdDTO)
            {
                int index = travelsByIdDTO.IndexOf(item);
                //בדיקה האם קיימות שתי נסיעות מאותו אזור
                if (travelsByIdDTO[index + 1].areaID == item.areaID)
                {
                    Contract min=new Contract();
                    Contract currentContract = new Contract();
                    foreach (var areaToContract in areaToContracts)
                    {
                        if (areaToContract.areaID == item.areaID)
                        {//מציאת חוזה מתאים לאזור
                            foreach (var contract in contracts)
                            {
                                if (areaToContract.contractID == contract.id)
                                {
                                    currentContract = contract;
                                    break;
                                }
                            }
                            if (min.freeDay > currentContract.freeDay)
                                min = currentContract;
                        }
                    }
                }

            }
            return travelsByIdDTO;
        }

    }


}
