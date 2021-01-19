using DALL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ModelDTO
{
    class AreasDTO
    {
        static RavKavEntities db = new RavKavEntities();
        public AreasDTO(int id)
        {
            this.id = id;
            name = db.Areas.Where(x => x.id == id).Select(x => x.name).ToString();
        }
        public int id { get; set; }
        public string name { get; set; }
    }
}
