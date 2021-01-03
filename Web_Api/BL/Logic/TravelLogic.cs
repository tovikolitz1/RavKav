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
        public static Node<TravelsDTO> GetTravelsById(int id)
        {
            #region declare
            //שליפת כל הנסיעות בצורה ממוינת לפי מחיר ואזור
            List<Travel> travelsById = new List<Travel>();
            travelsById = db.Travels.Where(x => x.id == id).OrderBy(x => x.price).ThenByDescending(x => x.areaID).ToList();
            Node<TravelsDTO> travelsByIdDTO = new Node<TravelsDTO>();
            Node<TravelsDTO> travelsByIdDTOpos = travelsByIdDTO;
            Node<TravelsDTO> travelsByIdDTOpos1 = travelsByIdDTO;
            List<Contract> contracts = new List<Contract>();
            contracts = db.Contracts.ToList();
            Node<contractsDTO> contractsDTO = new Node<contractsDTO>();
            Node<contractsDTO> contractsDTOpos = contractsDTO;
            List<AreaToContract> areaToContracts = new List<AreaToContract>();
            areaToContracts = db.AreaToContracts.ToList();
            Node<AreasDTO> areaToCurrentContractsDTO = new Node<AreasDTO>();
            Node<AreasDTO> areaToCurrentContractsDTOpos = areaToCurrentContractsDTO;
            Node<ContractExtensionHelp> contractUsed = new Node<ContractExtensionHelp>();
            Node<ContractExtensionHelp> contractUsedpos = contractUsed;
            Node<ContractExtensionHelp> contractUsedpos1;
            Node<AreasDTO> travelToCurrentContractDTO = new Node<AreasDTO>();
            Node<AreasDTO> travelToCurrentContractDTOpos = travelToCurrentContractDTO;
            int cntTravelInCntract = 0;
            IDictionary<int, string> areas = new Dictionary<int, string>(); ; //דיקשנרי של אזורים שבגללם בחרנו חודה מסוים
            #endregion
            //המרת רשימות ל DTO
            foreach (var item in contracts)
            {
                contractsDTOpos.Value(Convertions.Convertion(item));
                contractsDTOpos = contractsDTOpos.Next();
            }
            travelsByIdDTOpos = travelsByIdDTO;
            #region remarks
            //foreach (var item in areaToContracts)
            //{
            //    areaToCurrentContractsDTOpos.Value(Convertions.Convertion(item));
            //    areaToCurrentContractsDTOpos = areaToCurrentContractsDTOpos.Next();
            //}

            //foreach (var item in travelsById)
            //{//יצירת דיקשנרי של כל האזורים הקיימים למשתמש זה
            //    travelsByIdDTOpos.Value(Convertions.Convertion(item));
            //    travelsByIdDTOpos = travelsByIdDTOpos.Next();
            //    if (!areas.ContainsKey(item.areaID))
            //    {
            //        areas.Add(item.areaID, false);
            //    }
            //}
            #endregion
            //מעבר על רשימת הנסיעות ומציאת חוזה לשתי נסיעות זהות
            while (travelsByIdDTOpos != null && travelsByIdDTOpos.Next() != null)
            {

                //בדיקה האם קיימות שתי נסיעות מאותו אזור
                if (travelsByIdDTOpos.Value().areaID == travelsByIdDTOpos.Next().Value().areaID && !travelsByIdDTOpos.Value().used)
                {
                    contractsDTO min = new contractsDTO();
                    contractsDTO currentContract = new contractsDTO();
                    foreach (var areaToContract in areaToContracts)
                    {
                        if (areaToContract.areaID == travelsByIdDTOpos.Value().areaID)
                        {//מציאת חוזה מתאים לאזור
                            while (contractsDTOpos != null)
                            {
                                if (areaToContract.contractID == contractsDTOpos.Value().id)
                                {
                                    currentContract = contractsDTOpos.Value();
                                    areas.Add(areaToContract.contractID, "");
                                    break;
                                }
                                contractsDTOpos = contractsDTOpos.Next();
                            }
                            contractsDTOpos = contractsDTO;
                            if (min.freeDay > currentContract.freeDay)
                                min = currentContract;
                        }
                    }
                    areaToCurrentContractsDTOpos = areaToCurrentContractsDTO;

                    //יצירת רשימת אזורים שנכללים בחוזה
                    foreach (var item in areaToContracts)
                    {
                        if (item.contractID == currentContract.id)
                        {
                            areaToCurrentContractsDTOpos.Value(new AreasDTO(item.id));
                            areaToCurrentContractsDTOpos = areaToCurrentContractsDTOpos.Next();
                        }
                    }
                    areaToCurrentContractsDTOpos = areaToCurrentContractsDTO;
                    //הוספת נסיעות שמתאימות לחוזה הנבחר
                    while (travelsByIdDTOpos1 != null)
                    {

                        while (areaToCurrentContractsDTOpos != null)
                        {
                            if (travelsByIdDTOpos1.Value().areaID == areaToCurrentContractsDTOpos.Value().id && !travelsByIdDTOpos1.Value().used)
                            {
                                travelsByIdDTOpos1.Value().used = true;
                                cntTravelInCntract++;
                                if (!areas.ContainsKey(travelsByIdDTOpos1.Value().areaID))
                                    areas.Add(travelsByIdDTOpos1.Value().areaID, "");
                            }
                            areaToCurrentContractsDTOpos = areaToCurrentContractsDTOpos.Next();
                        }
                        travelsByIdDTOpos1 = travelsByIdDTOpos1.Next();
                        areaToCurrentContractsDTOpos = areaToCurrentContractsDTO;
                    }
                    travelsByIdDTOpos1 = travelsByIdDTO;
                    //בדיקה האם קיימות שלוש נסיעות
                    if (cntTravelInCntract < 3)
                    {
                        travelsByIdDTOpos.Value().used = false;
                        travelsByIdDTO.Next().Value().used = false;
                    }
                    else
                    {
                        contractUsedpos.Value(new ContractExtensionHelp(areas, currentContract.id, currentContract.freeDay));//דיקשנרי
                        contractUsedpos = contractUsedpos.Next();
                    }
                    areas.Clear();
                }
                travelsByIdDTOpos = travelsByIdDTOpos.Next();
            }
           
            travelsByIdDTOpos = travelsByIdDTO;
            //הוספת נסיעות בודדות לדיקשרי 
            while (travelsByIdDTOpos != null)
            {
                if (!travelsByIdDTOpos.Value().used)
                {
                    contractUsedpos.Value(new ContractExtensionHelp(travelsByIdDTOpos.Value().areaID, travelsByIdDTOpos.Value().id,travelsByIdDTOpos.Value().price));
                    contractUsedpos = contractUsedpos.Next();
                }
            }
            contractUsedpos = contractUsed;
            //חישוב הרחבת חוזים ונסיעות
            foreach (var item in areaToContracts)
            {
                while (contractUsedpos != null)
                { }
            }
            return travelsByIdDTO;
        }

    }


}
