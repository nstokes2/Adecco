using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Adecco.App_Data;
namespace Adecco.Models
{
    public class ContactContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ContactContext() : base("name=ContactContext")
        {
            Database.SetInitializer<ContactContext>(new ContactDBInitializer());
        }

        public System.Data.Entity.DbSet<Adecco.Models.Contact> Contacts { get; set; }
    }

    public class ContactDBInitializer : DropCreateDatabaseAlways<ContactContext>
    {

        protected override void Seed(ContactContext context)
        {
            IList<Contact> contacts = new List<Contact>();

            XMLReader xmlRead = new XMLReader();

            var data = xmlRead.ReturnContacts();

            for(int i = 0; i<data.Count; i++)
            contacts.Add(data[i]);



            foreach (Contact contact in contacts)
                context.Contacts.Add(contact);
            base.Seed(context);
        }



    }
}
