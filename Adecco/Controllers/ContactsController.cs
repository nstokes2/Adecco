using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Adecco.Models;
using Adecco.App_Data;

namespace Adecco.Controllers
{
    public class ContactsController : Controller
    {
        private ContactContext db = new ContactContext();


        // GET: Contacts

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
            Contact[] one = { data.ToList().ElementAt(10), data.ToList().ElementAt(11),
            data.ToList().ElementAt(12), data.ToList().ElementAt(13),
            data.ToList().ElementAt(14), data.ToList().ElementAt(15),
            data.ToList().ElementAt(16), data.ToList().ElementAt(17),
            data.ToList().ElementAt(18), data.ToList().ElementAt(19)
            };

            Contact[] two = { data.ToList().ElementAt(20), data.ToList().ElementAt(21),
            data.ToList().ElementAt(22), data.ToList().ElementAt(23),
            data.ToList().ElementAt(24)};

            if (id == 0)
                return View(zero.ToList());

            if (id == 1)
                return View(one.ToList());
            else
                return View(two.ToList());
        }

        // GET: Contacts/Details/5
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

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,BusinessNumber,HomeNumber,MobileNumber,Address,NOtes")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,BusinessNumber,HomeNumber,MobileNumber,Address,NOtes")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
