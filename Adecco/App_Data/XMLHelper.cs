using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Adecco.App_Data
{
    [Serializable]
    [XmlRoot("contacts"), XmlType("contacts")]
    public class XMLHelper
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string BusinessNumber { get; set; }
        public string HomeNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
    }
}
