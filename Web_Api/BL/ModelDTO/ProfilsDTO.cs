using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ModelDTO
{
    class ProfilsDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string discountPercentage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserTbl> UserTbls { get; set; }
    }
}
