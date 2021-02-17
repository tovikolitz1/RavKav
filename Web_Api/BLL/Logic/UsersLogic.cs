
using BLL.ModelDTO;
using DALL;
using System;
using System.Collections.Generic;
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
        public static bool forgotPassword(string ravkav)
        {
            User u = db.Users.Where(x => x.ravkavNum == ravkav).FirstOrDefault();
            if (u == null)
                return false;
            int fUserID = u.id;
           var vcid=  db.sp_vretificationCode_Insert(fUserID);
            int y = 0;
            if (vcid == null)
            {
                return false;
            }
           
            string to= u.email;
            if (to != null)
            {
                string from = "mykav@gmail.com";
                string subject = "שחזור סיסמה";
                VertificationCode ver = db.VertificationCodes.Where(x => x.id ==y).FirstOrDefault();
                if (ver == null)
                    return false;
                string tempPass = ver.verificationCode;
                string body = "הסיסמה הזמנית שלך היא" +tempPass;
                MailMessage massage = new MailMessage(from, to, subject, body);
                SendMessege.send(massage);
                return true;
            }
            else { return false; }
        }
        public static bool changePassword(string ravkav,string tempPass,string newPass)
        {
            var u = db.Users.Where(x => x.ravkavNum == ravkav).FirstOrDefault();
            if (u == null)
                return false;
            int id = u.id;
            VertificationCode tempPassEmail= db.VertificationCodes.Where(x => x.fUserID == id).FirstOrDefault();
            if (tempPassEmail == null||tempPassEmail.CreateDate<DateTime.Now.AddMinutes(-30)|| tempPass != tempPassEmail.verificationCode)
                return false;
          
          
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
