using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ModelDTO
{
    class TravelsDTO
    {
        public int id { get; set; }
        public System.DateTime dateAndTime { get; set; }
        public int userId { get; set; }
        public int TransitId { get; set; }

        public virtual TransitTbl TransitTbl { get; set; }
        public virtual UserTbl UserTbl { get; set; }
    }
}
