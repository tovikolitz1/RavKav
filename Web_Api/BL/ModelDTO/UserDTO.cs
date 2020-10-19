using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ModelDTO
{
    public class UserDTO
    {
        public int id { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string email { get; set; }
        public bool isManager { get; set; }
        public string pass { get; set; }
        public string ravkavNum { get; set; }
        public Nullable<int> profileId { get; set; }

    }
}
