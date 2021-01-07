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

        public static void GetTravelsByIdAndMonth(int id, DateTime time)
        {
            //שליפה של כל החודש לפי שנה למשתמש מסוים
            List<Travel> travelsById = db.Travels.Where(x => x.userID == id && x.date.Year == time.Year && x.date.Month == time.Month).OrderBy(x => x.price).ThenByDescending(x => x.areaID).ToList();
            //שליפה של כל החוזים שמתאימים לנסיעות של המשתמש
            List<Contract> contracts = db.Contracts.Where(x => x.AreaToContracts.Any(m => m.Area.Travels.Any(f => (f.userID == id && f.date.Year == time.Year && f.date.Month == time.Month)))).ToList();
            for (int i = 0; i < 28; i++)
            {
                findContractBase(contracts.Where(x => x.AreaToContracts.Any(m => m.Area.Travels.Any(f => (f.userID == id && f.date.Year == time.Year && f.date.Month == time.Month && f.date.Day == i)))).ToList(), travelsById.Where(x => x.date.Day == i).ToList());
            }

        }
        //להוסיף לדיקנשרי של החוזים שבחרנו בהם את הנסיעות שלא נכנסו באף חוזה 
        public static void findContractBase(List<Contract> contracts, List<Travel> travelsById)
        {
            IDictionary<Travel, int> travelUsed = new Dictionary<Travel, int>();
            IDictionary<int, List<Area>> contractUsed = new Dictionary<int, List<Area>>();//דיקשנרי של חוזים שכל אחד מכיל רשימת אזורים שבגללם בחרנו את החוזה
            int cnt = 0;
            //מעבר על רשימת הנסיעות למשתמש
            for (int i = 0; i < travelsById.Count; i++)
            {
                //בדיקה האם שתי הנסיעות מאותו אזור
                if (travelsById[i].areaID == travelsById[i + 1].areaID)
                {//מציאת החוזה המתאים והזול
                    var currentContractID = travelsById[i].Area.AreaToContracts.OrderBy(x => x.Contract.freeDay).FirstOrDefault().id;
                    //שליפת כל הנסיעות המתאימות לחוזה
                    var travelsToCurrentContract = travelsById.Where(x => x.Area.AreaToContracts.Any(m => m.contractID == currentContractID));
                    foreach (var item in travelsToCurrentContract)
                    {//בדיקה האם חלק מהנסיעות כבר מומשו בחוזים אחרים
                        if (!travelUsed.ContainsKey(item))
                            cnt++;
                    }
                    //בדיקה שיש יותר משלוש נסיעות שלא מומשו באף חוזה ותואמות את החוזה הנבחר
                    if (cnt > 2)
                    {
                        //הוספת הנסיעות לדיקשנרי של נסיעות שכבר נמצאות בחוזים
                        foreach (var item in travelsToCurrentContract)
                        {
                            if (!travelUsed.ContainsKey(item))
                                travelUsed.Add(item, 0);
                        }
                    }
                }
            }

        }

        public static void contractExtention(List<Contract> contracts, List<Travel> travelsById, Dictionary<int, List<Area>> contractUsed)
        {
            for (int i = 0; i < contractUsed.Count() - 1; i++)
            {
                contracts.Where(x => x.AreaToContracts.Where(y =>    )
                //להשוות לרשימת האזורים לחוזה הראשון והשני
                //במידה ומכיל את הכל והמנימלי במחיר לבחור אותו ולסמן עוד חוזים או נסיעות שיכלות להכלל בתוכו

            }
        }
    }

}
