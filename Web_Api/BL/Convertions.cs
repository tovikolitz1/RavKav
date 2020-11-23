using BL.ModelDTO;
using DAL;
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
            AreasDTO newarea = new AreasDTO();
            newarea.id = areaTbl.id;
            newarea.name = areaTbl.name;
            return newarea;
        }
        public static Area Convertion(AreasDTO area)
        {
            Area newarea = new Area();
            newarea.id = area.id;
            newarea.name = area.name;
            return newarea;
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
            newprofile.discount = profileTbl.discount;
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
        public static TransitDTO Convertion(Transit transitTbl)
        {
            TransitDTO newTransit = new TransitDTO();

            newTransit.id = transitTbl.id;
            newTransit.buss = transitTbl.bas;
            newTransit.price = transitTbl.price;
            newTransit.areaID = transitTbl.areaID;
            newTransit.internalOrIntermediate = transitTbl.InternalOrIntermediate;
            newTransit.transitTrip = transitTbl.transitTrip;
            newTransit.userID = transitTbl.userID;
            newTransit.date = transitTbl.date;
            return newTransit;
        }
        public static Transit Convertion(TransitDTO transit)
        {
            Transit newTransit = new Transit();

            newTransit.id = transit.id;
            newTransit.bas = transit.buss;
            newTransit.price = transit.price;
            newTransit.areaID = transit.areaID;
            newTransit.InternalOrIntermediate = transit.internalOrIntermediate;
            newTransit.transitTrip = transit.transitTrip;
            newTransit.userID = transit.userID;
            newTransit.date = transit.date;
            return newTransit;
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
