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
            List<contractsDTO> contractsDTO = new List<contractsDTO>();
            List<AreaToContract> areaToContracts = new List<AreaToContract>();
            areaToContracts = db.AreaToContracts.ToList();
            List<AreaToContractsDTO> areaToContractsDTO = new List<AreaToContractsDTO>();
            List<TravelsDTO> travelsByIdDTO = new List<TravelsDTO>();
            IDictionary<int, bool> areas = new Dictionary<int, bool>();
            IDictionary<int, contractsDTO> contractUsed = new Dictionary<int, contractsDTO>();
            List<AreasDTO> areaToCurrentContract = new List<AreasDTO>();
            int cntTravelInCntract = 0;
            //המרת רשימות ל DTO
            foreach (var item in contracts)
            {
                contractsDTO.Add(Convertions.Convertion(item));
            }

            foreach (var item in areaToContracts)
            {
                areaToContractsDTO.Add(Convertions.Convertion(item));
            }

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
                if (travelsByIdDTO[index + 1].areaID == item.areaID && !item.used)
                {
                    contractsDTO min = new contractsDTO();
                    contractsDTO currentContract = new contractsDTO();
                    foreach (var areaToContract in areaToContracts)
                    {
                        if (areaToContract.areaID == item.areaID)
                        {//מציאת חוזה מתאים לאזור
                            foreach (var contract in contractsDTO)
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
                    //יצירת רשימת אזורים שנכללים בחוזה
                    foreach (var con in areaToContractsDTO)
                    {
                        if (con.contractID == currentContract.id)
                            areaToCurrentContract.Add(new AreasDTO(con.id));
                    }
                    //הוספת נסיעות שמתאימות לחוזה הנבחר
                    foreach (var travel in travelsByIdDTO)
                    {
                        foreach (var area in areaToCurrentContract)
                        {
                            if (travel.areaID == area.id && !travel.used)
                            {
                                travel.used = true;
                                cntTravelInCntract++;
                            }
                        }

                    }
                    if (cntTravelInCntract < 3)
                    {
                        item.used = false;
                        travelsByIdDTO[index + 1].used = false;
                    }
                    else
                        contractUsed.Add(currentContract.id, currentContract);
                }

            }
            return travelsByIdDTO;
        }

    }


}
