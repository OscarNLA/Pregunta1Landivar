using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcLandivarPr1.Models;
using Pr1LandivarAPI.Models;

namespace MvcLandivarPr1.Controllers
{
    public class LandivarsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Landivars
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Landivars.ToList());
        }

        // GET: Landivars/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Landivar landivar = db.Landivars.Find(id);
            if (landivar == null)
            {
                return HttpNotFound();
            }
            return View(landivar);
        }

        // GET: Landivars/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Landivars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LandivarID,FriendofLandivar,Place,Email,Birthdate")] Landivar landivar)
        {
            if (ModelState.IsValid)
            {
                db.Landivars.Add(landivar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(landivar);
        }

        // GET: Landivars/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Landivar landivar = db.Landivars.Find(id);
            if (landivar == null)
            {
                return HttpNotFound();
            }
            return View(landivar);
        }

        // POST: Landivars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LandivarID,FriendofLandivar,Place,Email,Birthdate")] Landivar landivar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(landivar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(landivar);
        }

        // GET: Landivars/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Landivar landivar = db.Landivars.Find(id);
            if (landivar == null)
            {
                return HttpNotFound();
            }
            return View(landivar);
        }

        // POST: Landivars/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Landivar landivar = db.Landivars.Find(id);
            db.Landivars.Remove(landivar);
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
