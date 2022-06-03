using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memberManagment.Data
{
    public class CitiesModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int countryid { get; set; }
        public CountriesModel  country  { get; set; }

    }
}
