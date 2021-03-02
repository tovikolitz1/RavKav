
using BLL.ModelDTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace BLL.Logic
{

    public static class UsersLogic
    {
       
        static RavKavEntities db = new RavKavEntities();
        public static List<UserDTO> GetUsersList(int id)
        {
            if(db.Users.FirstOrDefault(x=>x.id==id).isManager)
            {
              return Convertions.Convertion(db.Users.Where(y => !y.isManager || y.id == id).ToList());

            }
            return null;
        }

        public static UserDTO UserDetails(int id)
        {
            return Convertions.Convertion(db.Users.FirstOrDefault(x => x.id == id));
        }
        public static bool AddUser(UserDTO user)
        {
            
            db.sp_addUder_Insert(user.fName, user.lName, user.email, user.pass, user.ravkav, user.profileId);

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
        public static void SendMail(string subjecct, string body, string Address, string from = null)
        {
            MailMessage msg = new MailMessage() { From = new MailAddress(from, "MyKav") };
            if (from != null)
            {
                msg.ReplyToList.Add(from);
            }
            msg.To.Add(Address);
            msg.Subject = subjecct;
            msg.Body = body;
            msg.IsBodyHtml = true;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(from,"0583284840");
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(msg);
                }
            }
            catch (Exception e)
            {
                throw e;

            }
        }
        public static bool forgotPassword(string ravkav)
        {
            User u = db.Users.FirstOrDefault(x => x.ravkavNum == ravkav);
            if (u == null)
                return false;
            int fUserID = u.id;
            var vcid = db.sp_vretificationCode_Insert(fUserID).FirstOrDefault();
            if (vcid == null)
            {
                return false;
            }
            int vc = Convert.ToInt32(vcid);
            string to = u.email;
            if (to != null)
            {
                string from = "mykav2021@gmail.com";
                string subject = "שחזור סיסמה";
                VertificationCode ver = db.VertificationCodes.Where(x => x.id == vc).FirstOrDefault();
                if (ver == null)
                    return false;
                string tempPass = ver.verificationCode;
                string body = " הסיסמה הזמנית שלך היא" + tempPass;
                SendMail(subject, body, to, from);
                return true;
            }
            else { return false; }
        }
        public static bool changePassword(string ravkav, string tempPass, string newPass)
        {
            var u = db.Users.Where(x => x.ravkavNum == ravkav).FirstOrDefault();
            if (u == null)
                return false;
            int id = u.id;
            VertificationCode tempPassEmail = db.VertificationCodes.Where(p => p.fUserID == id).OrderByDescending(o=>o.CreateDate).FirstOrDefault();
             if (tempPassEmail == null || tempPassEmail.CreateDate < DateTime.Now.AddMinutes(-30) || tempPass != tempPassEmail.verificationCode)
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
        public static bool updateAsManager(int mID, int uID)
        {
            if (db.Users.Where(y => y.id == mID).FirstOrDefault().isManager == false)
                return false;
            var u = db.Users.Where(t => t.id == uID).FirstOrDefault();
            if (u == null)
                return false;
            u.isManager = true;
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
                db.Entry<User>(u).State = System.Data.Entity.EntityState.Modified;
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
            return db.Users.Where(x => x.id == id).Select(x => x.fName + " " + x.lName).FirstOrDefault();
        }
    }
}
