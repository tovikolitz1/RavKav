
using BLL.ModelDTO;
using DALL;
using System;
using System.Linq;
using System.Net.Mail;

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
        public static bool forgotPassword(int id)
        {
           string to= db.Users.Where(x => x.id == id).FirstOrDefault().ToString();
            if (to != null)
            {
                string from = "mykav@gmail.com";
                string subject = "שחזור סיסמה";
                Random rnd = new Random();
                rnd.Next(100000, 999999);
                string body = "הסיסמה הזמנית שלך היא" + rnd;
                MailMessage massage = new MailMessage(from, to, subject, body);
                SendMessege.send(massage);
                return true;
            }
            else { return false; }
        }
        public static bool changePassword(string tempPass,string newPass, int id,string rnd)
        {
            if (tempPass != rnd)
                return false;
            User u = db.Users.Where(x => x.id == id).FirstOrDefault();
            if (u != null)
            {
                u.pass = newPass;
                try
                {
                    db.Users.Attach(u);
                    db.Entry(u).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else
                return false;
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
