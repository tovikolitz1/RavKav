
using BLL.ModelDTO;
using DALL;
using System;
using System.Linq;


namespace BLL.Logic
{

    public static class UsersLogic
    { 
        static RavKavEntities db = new RavKavEntities();

        public static bool AddUser(UserDTO user)
        {
            User u = Convertions.Convertion(user);
            try
            {
                
                    db.Users.Add(u);
                    db.SaveChanges();
                    return true;
            }
            catch 
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
        public static UserDTO IfExsistRavKav(string ravKav, string pass)
        {
            User user = db.Users.ToList().FirstOrDefault(x => x.ravkavNum == ravKav && x.pass == pass);
            if (user != null)
            {
                return Convertions.Convertion(user);
            }
            
            return null;
        }                                                                                                                            
        public static string GetNameById(int id)                                                                                     
        {                                                                                                 
             return db.Users.Where(x=> x.id==id).Select(x=> x.fName+" "+x.lName).ToString();                               
        }                                                                                                                            
    }
}
