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
        // שליפת כל הנסיעות של משתמש
        public static List<TravelsDTO> GetTravelsById(int id)
        {
            //לבדוק איך אפשר להחזיר רשימה מסוג נסיעות
            List<Travel> travelsById = new List<Travel>();
            travelsById = db.Travels.Where(x => x.id == id).ToList();
            List<TravelsDTO> travelsByIdDTO = Convertions.Convertion(travelsById);   
            return travelsByIdDTO;
        }
        ////מציאת שתי נסיעות הכי יקרות
        //public static List<string> GetExpenciveTravel(int id)
        //{
        //    //לא גמור
        //    //איך להוציא רק שתי נסיעות 
        //    List<string> expenciveTravel = new List<string>();
        //    expenciveTravel = db.Transits.Where(x => x.id == id).Select(x => x.id + x.bas + x.price + x.areaID + x.InternalOrIntermediate + x.transitTrip + x.userID + x.date).ToList();
        //    return expenciveTravel;
        //}
    }
       
       
}
