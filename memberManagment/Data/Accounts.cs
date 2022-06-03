using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memberManagment.Data
{
    public class Accounts
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

      
        public string LastName { get; set; }

        
        public string Country { get; set; }

        
        public string City { get; set; }
       
        public string gender { get; set; }
       
        public DateTime? Birth { get; set; }
        
        public string phone { get; set; }
        
        public string Email { get; set; }
       
        public string Note { get; set; }
       
        public bool status { get; set; }
      
        public string imageurl { get; set; }
    }
}
