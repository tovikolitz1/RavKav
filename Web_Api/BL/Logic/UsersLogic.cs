
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
        static RavKav db = new RavKav();

        public static bool AddUser(UserDTO user)
        {
            User u = Convertions.Convertion(user);
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
        public static bool UpdateUser(UserDTO user)
        {
            User u = Convertions.Convertion(user);
            try
            {
                db.Users.Attach(u);
                db.Entry<User>(u).State=System.Data.Entity.EntityState.Modified;
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
            User user = db.Users.ToList().FirstOrDefault(x => x.ravkavNum == ravKav && x.pass == pass);
            if (user == null)
                return null;
            return Convertions.Convertion(user);
        }                                                                                                                            
        public static string GetNameById(int id)                                                                                     
        {                                                                                                                            
             return db.Users.Where(x=> x.id==id).Select(x=> x.fName+" "+x.lName).ToString();                               
        }                                                                                                                            
    }
}
