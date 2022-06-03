using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memberManagment.Data
{
    public class CountriesModel
    {
        public int id { get; set; }
        public string name { get; set; }
      
        public List <CitiesModel> cities { get; set; }

    }
}
