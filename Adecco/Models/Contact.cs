using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Adecco.Models
{
    public class Contact
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string BusinessNumber { get; set; }
        public string HomeNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }

        public Contact()
        {







        }
    }
}