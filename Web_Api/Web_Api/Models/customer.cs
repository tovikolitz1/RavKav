using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Api.Models
{
    public class Customer
    {
        public int CustCode { get; set; }
        public string CustID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public List<object> ListSubscription { get; set; }
        
 

    }
}