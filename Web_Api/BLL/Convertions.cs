using BL.ModelDTO;
using DALL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class Convertions
    {
        public static AreasDTO Convertion(Area areaTbl)
        {
            return  new AreasDTO(areaTbl.id) {
                id = areaTbl.id,
                name = areaTbl.name
            };
           
           
        }
        public static Area Convertion(AreasDTO area)
        {
            return new Area() {
            id = area.id,
            name = area.name
            };
            
        }
        public static AreaToContractsDTO Convertion(AreaToContract areaToContractsTbl)
        {
            AreaToContractsDTO newareaToContracts = new AreaToContractsDTO();
            newareaToContracts.id = areaToContractsTbl.id;
            newareaToContracts.areaID = areaToContractsTbl.areaID;
            newareaToContracts.contractID = areaToContractsTbl.contractID;
            return newareaToContracts;
        }

        public static AreaToContract Convertion(AreaToContractsDTO areaToContracts)
        {
            AreaToContract newareaToContracts = new AreaToContract();
            newareaToContracts.id = areaToContracts.id;
            newareaToContracts.areaID = areaToContracts.areaID;
            newareaToContracts.contractID = areaToContracts.contractID;
            return newareaToContracts;
        }
        public static contractsDTO Convertion(Contract contractTbl)
        {
            contractsDTO newContract = new contractsDTO();
            newContract.id = contractTbl.id;
            newContract.freeDay = contractTbl.freeDay;
            newContract.freeMonth = contractTbl.freeMounth;
            return newContract;
        }
        public static Contract Convertion(contractsDTO contract)
        {
            Contract newContract = new Contract();
            newContract.id = contract.id;
            newContract.freeDay = contract.freeDay;
            newContract.freeMounth = contract.freeMonth;
            return newContract;
        }
        public static ProfilsDTO Convertion(Profile profileTbl)
        {
            ProfilsDTO newprofile = new ProfilsDTO();
            newprofile.id = profileTbl.id;
          //  newprofile.discount = profileTbl.discount;
            newprofile.describe = profileTbl.describe;
            return newprofile;
        }
        public static Profile Convertion(ProfilsDTO profile)
        {
            Profile newprofile = new Profile();
            newprofile.id = profile.id;
            newprofile.discount = profile.discount;
            newprofile.describe = profile.describe;
            return newprofile;
        }
        public static TravelsDTO Convertion(Travel travelTbl)
        {
            TravelsDTO newTravel = new TravelsDTO();

            newTravel.id = travelTbl.id;
            newTravel.buss = travelTbl.bas;
            newTravel.price = travelTbl.price;
            newTravel.areaID = travelTbl.areaID;
            //newTravel.internalOrIntermediate = travelTbl.InternalOrIntermediate;
            newTravel.trvelTrip = travelTbl.travelTrip;
            newTravel.userID = travelTbl.userID;
            newTravel.date = travelTbl.date;
            return newTravel;
        }
        public static Travel Convertion(TravelsDTO travel)
        {
            Travel newTravel = new Travel();
            newTravel.id = travel.id;
            newTravel.bas = travel.buss;
            newTravel.price = travel.price;
            newTravel.areaID = travel.areaID;
           // newTravel.InternalOrIntermediate = travel.internalOrIntermediate;
            newTravel.travelTrip = travel.trvelTrip;
            newTravel.userID = travel.userID;
            newTravel.date = travel.date;
            return newTravel;
        }
        public static UserDTO Convertion(User userTbl)
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
        public static User Convertion(UserDTO user)
        {
            User newUser = new User();
            newUser.fName = user.fName;
            newUser.lName = user.lName;
            newUser.pass = user.pass;
            newUser.profileId = user.profileId;
            newUser.ravkavNum = user.ravkavNum;
            newUser.id = user.id;
            newUser.isManager = user.isManager;
            return newUser;
        }
    }
}
