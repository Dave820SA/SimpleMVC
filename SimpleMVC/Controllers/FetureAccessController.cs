using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserBusinessLayer;

namespace SimpleMVC.Controllers
{
    public class FetureAccessController : Controller
    {
        private ActivityContext db = new ActivityContext();

        //
        // GET: /FetureAccess/

        public ActionResult Index()
        {
            var featureaccesses = db.FeatureAccesses.Include("SIA_AppFeature").Include("User");
            return View(featureaccesses.ToList());
        }

        //
        // GET: /FetureAccess/Details/5

        public ActionResult Details(int id = 0)
        {
            FeatureAccess featureaccess = db.FeatureAccesses.Single(f => f.AppFeatureAccessID == id);
            if (featureaccess == null)
            {
                return HttpNotFound();
            }
            return View(featureaccess);
        }

        //
        // GET: /FetureAccess/Create

        public ActionResult Create()
        {
            ViewBag.AppFeatureID = new SelectList(db.Features, "AppFeatureID", "Name");
            ViewBag.AppEntityID = new SelectList(db.Users, "AppEntityID", "PIN");
            return View();
        }

        //
        // POST: /FetureAccess/Create

        [HttpPost]
        public ActionResult Create(FeatureAccess featureaccess)
        {
            if (ModelState.IsValid)
            {
                db.FeatureAccesses.AddObject(featureaccess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppFeatureID = new SelectList(db.Features, "AppFeatureID", "Name", featureaccess.AppFeatureID);
            ViewBag.AppEntityID = new SelectList(db.Users, "AppEntityID", "PIN", featureaccess.AppEntityID);
            return View(featureaccess);
        }

        //
        // GET: /FetureAccess/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FeatureAccess featureaccess = db.FeatureAccesses.Single(f => f.AppFeatureAccessID == id);
            if (featureaccess == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppFeatureID = new SelectList(db.Features, "AppFeatureID", "Name", featureaccess.AppFeatureID);
            ViewBag.AppEntityID = new SelectList(db.Users, "AppEntityID", "PIN", featureaccess.AppEntityID);
            return View(featureaccess);
        }

        //
        // POST: /FetureAccess/Edit/5

        [HttpPost]
        public ActionResult Edit(FeatureAccess featureaccess)
        {
            if (ModelState.IsValid)
            {
                db.FeatureAccesses.Attach(featureaccess);
                db.ObjectStateManager.ChangeObjectState(featureaccess, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppFeatureID = new SelectList(db.Features, "AppFeatureID", "Name", featureaccess.AppFeatureID);
            ViewBag.AppEntityID = new SelectList(db.Users, "AppEntityID", "PIN", featureaccess.AppEntityID);
            return View(featureaccess);
        }

        //
        // GET: /FetureAccess/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FeatureAccess featureaccess = db.FeatureAccesses.Single(f => f.AppFeatureAccessID == id);
            if (featureaccess == null)
            {
                return HttpNotFound();
            }
            return View(featureaccess);
        }

        //
        // POST: /FetureAccess/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            FeatureAccess featureaccess = db.FeatureAccesses.Single(f => f.AppFeatureAccessID == id);
            db.FeatureAccesses.DeleteObject(featureaccess);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}