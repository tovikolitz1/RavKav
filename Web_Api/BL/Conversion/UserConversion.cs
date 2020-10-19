using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Threading.Tasks;
using BL.ModelDTO;

namespace BL.Convertion
{
    public class UserConversion
    {
        public static UserDTO convertToUserDto(User userTbl)
        {
            UserDTO newUser = new UserDTO();
            newUser.fName = userTbl.fName;
            newUser.lName = userTbl.lName;
            newUser.pass = userTbl.pass;
            newUser.profileId = userTbl.profileId;
            newUser.ravkavNum = userTbl.ravkavNum;
            newUser.id = userTbl.id;
            newUser.isManager = userTbl.isManager;
            return newUser;
        }
        public static User ConvertToUserTbl(UserDTO userTbl)
        {
            User newUser = new User();
            newUser.fName = userTbl.fName;
            newUser.lName = userTbl.lName;
            newUser.pass = userTbl.pass;
            newUser.profileId = userTbl.profileId;
            newUser.ravkavNum = userTbl.ravkavNum;
            newUser.id = userTbl.id;
            newUser.isManager = userTbl.isManager;
            return newUser;
        }

    }
}
