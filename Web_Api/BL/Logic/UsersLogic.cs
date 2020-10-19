using BL.Extentions;
using BL.ModelDTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class UsersLogic
    {
        static RavKavEntities db = new RavKavEntities();

        public static bool AddUser(UserDTO user)
        {
            User u = Extend.CreateUserTbl(user);
            try
            {
               
                    db.Users.Add(u);
                    db.SaveChanges();
                    return true;
                
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static int CalculateThePayment(string id)
        {
            return 1;
        }
        public static UserDTO IfExsistRavKav(string ravKav, string pass)
        {
            User userTbl = db.Users.ToList().FirstOrDefault(x => x.ravkavNum == ravKav && x.pass == pass);
            if (userTbl == null)
                return null;
            return Convertion.UserConversion.convertToUserDto(userTbl);
            //return db.UserTbls.ToList().Where(a => a.ravkav.Equals(ravKav) && a.password.Equals(pass)).Select(item => new UserDTO { id = item.id, isManager = item.isManager, ravkav = item.ravkav, password = item.password, firstName = item.firstName, lastName = item.lastName, profileId = item.profileId}).FirstOrDefault();
        }                                                                                                                            
        public static string GetNameById(int id)                                                                                     
        {                                                                                                                            
             return db.UserTbls.Where(x=> x.id==id).Select(x=> x.firstName+" "+x.lastName).ToString();                               
        }                                                                                                                            
    }
}
