using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace memberManagment.Models
{
    public class AddMemeberModel
    {
        public int id { get; set; } = 0;
        [Required(ErrorMessage = "please Enter your  first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "please Enter your  last name")]
        public string LastName { get; set; }


        public int Country { get; set; }


        public int City { get; set; }

        public string gender { get; set; }

        public DateTime? Birth { get; set; }

        public string phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Note { get; set; }

        public bool status { get; set; }

        public string imageurl { get; set; }
        public IFormFile image { get; set; }
    
}
}
