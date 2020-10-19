using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ModelDTO
{
    class TransitDTO
    {
        public int id { get; set; }
        public int number { get; set; }
        public int cardId { get; set; }
        public virtual CardTbl CardTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TravelsTbl> TravelsTbls { get; set; }
    }
}
