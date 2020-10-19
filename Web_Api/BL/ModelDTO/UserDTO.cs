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
        public bool isManager { get; set; }
        public string ravkav { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int profileId { get; set; }
       
    }
}
