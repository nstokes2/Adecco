using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using Adecco.Models;

namespace Adecco.App_Data
{
    class XMLReader
    {
    

    public List<Contact> ReturnContacts()
    {

        string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/contacts.xml");

        DataSet data = new DataSet();

        data.ReadXml(xmlData);

        var contacts = new List<Contact>();
        int i = 0;
        contacts = (from rows in data.Tables[0].AsEnumerable()
                    select new Contact
                    {
                        Id = i++,
                        Name = rows[0].ToString(),
                        Email = rows[1].ToString(),
                        BusinessNumber = rows[2].ToString(),
                        HomeNumber = rows[3].ToString(),
                        MobileNumber = rows[4].ToString(),
                        Address = rows[5].ToString(),
                        Notes = rows[6].ToString()
                    }).ToList();
        return contacts;





            }
        public Contact Details(int? id)
        {

            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/contacts.xml");

            DataSet data = new DataSet();

            data.ReadXml(xmlData);

            var contacts = new List<Contact>();
            int i = 0;
            contacts = (from rows in data.Tables[0].AsEnumerable()
                        select new Contact
                        {
                            Id = i++,
                            Name = rows[0].ToString(),
                            Email = rows[1].ToString(),
                            BusinessNumber = rows[2].ToString(),
                            HomeNumber = rows[3].ToString(),
                            MobileNumber = rows[4].ToString(),
                            Address = rows[5].ToString(),
                            Notes = rows[6].ToString()
                        }).ToList();


            return contacts.ElementAt(id.Value);





        }


    }
}
