using BL.ModelDTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Extentions
{
    public class Extend
    {
        public static UserTbl CreateUserTbl(UserDTO u)
        {
            UserTbl u1 = new UserTbl()
            {
                id = u.id,
                isManager = u.isManager,
                ravkav = u.ravkav,
                password = u.password,
                firstName = u.firstName,
                lastName = u.lastName,
                profileId = u.profileId
            };
            return u1;
        }
    }
}
