using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Adecco.App_Data;
using Adecco.Models;

namespace Adecco.Controllers
{
    public class contactXmlController : Controller
    {
        // GET: contactXml
        public ActionResult Index(int id)
        {
            XMLReader readXML = new XMLReader();

            var data = readXML.ReturnContacts();

            Contact[] zero = { data.ToList().ElementAt(0), data.ToList().ElementAt(1),
            data.ToList().ElementAt(2), data.ToList().ElementAt(3),
            data.ToList().ElementAt(4), data.ToList().ElementAt(5),
            data.ToList().ElementAt(6), data.ToList().ElementAt(7),
            data.ToList().ElementAt(8), data.ToList().ElementAt(9)
            };
            Contact[] one= { data.ToList().ElementAt(10), data.ToList().ElementAt(11),
            data.ToList().ElementAt(12), data.ToList().ElementAt(13),
            data.ToList().ElementAt(14), data.ToList().ElementAt(15),
            data.ToList().ElementAt(16), data.ToList().ElementAt(17),
            data.ToList().ElementAt(18), data.ToList().ElementAt(19)
            };

            Contact[] two = { data.ToList().ElementAt(20), data.ToList().ElementAt(21),
            data.ToList().ElementAt(22), data.ToList().ElementAt(23),
            data.ToList().ElementAt(24)};

            if(id==0)
                return View(zero.ToList());

            if (id == 1)
                return View(one.ToList());
            else
                return View(two.ToList());
        }
        // GET: contactXml/Details/5
        public ActionResult Details(int? id)
        {
            XMLReader readXML = new XMLReader();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = readXML.Details(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }
    }
}