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
        public static UserDTO convertToUserDto(UserTbl userTbl)
        {
            UserDTO newUser = new UserDTO();
            newUser.firstName = userTbl.firstName;
            newUser.lastName = userTbl.lastName;
            newUser.password = userTbl.password;
            newUser.profileId = userTbl.profileId;
            newUser.ravkav = userTbl.ravkav;
            newUser.id = userTbl.id;
            newUser.isManager = userTbl.isManager;
            return newUser;
        }
        public static UserTbl ConvertToUserTbl(UserDTO userDto)
        {
            UserTbl newUser = new UserTbl();
            newUser.firstName = userDto.firstName;
            newUser.lastName = userDto.lastName;
            newUser.password = userDto.password;
            newUser.profileId = userDto.profileId;
            newUser.ravkav = userDto.ravkav;
            newUser.id = userDto.id;
            newUser.isManager = userDto.isManager;
            return newUser;
        }

    }
}
