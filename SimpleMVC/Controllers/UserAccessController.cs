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
    public class UserAccessController : Controller
    {
        private ActivityContext db = new ActivityContext();

        //
        // GET: /UserAccess/

        public ActionResult Index()
        {
            var websiteusers = db.WebSiteUsers.Include("SIA_WebLinks").Include("SIA_WebRole").Include("User_User");
            return View(websiteusers.ToList());
        }

        //
        // GET: /UserAccess/Details/5

        public ActionResult Details(int id = 0)
        {
            WebSiteUser websiteuser = db.WebSiteUsers.Single(w => w.WebSiteUserID == id);
            if (websiteuser == null)
            {
                return HttpNotFound();
            }
            return View(websiteuser);
        }

        //
        // GET: /UserAccess/Create

        public ActionResult Create()
        {
            ViewBag.WebLinkID = new SelectList(db.WebLinks, "WebLinkID", "Name");
            ViewBag.WebSiteRoleID = new SelectList(db.UserRoles, "WebRoleID", "WebRole");
            ViewBag.AppEntityID = new SelectList(db.Users, "AppEntityID", "PIN");
            return View();
        }

        //
        // POST: /UserAccess/Create

        [HttpPost]
        public ActionResult Create(WebSiteUser websiteuser)
        {
            if (ModelState.IsValid)
            {
                db.WebSiteUsers.AddObject(websiteuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WebLinkID = new SelectList(db.WebLinks, "WebLinkID", "Name", websiteuser.WebLinkID);
            ViewBag.WebSiteRoleID = new SelectList(db.UserRoles, "WebRoleID", "WebRole", websiteuser.WebSiteRoleID);
            ViewBag.AppEntityID = new SelectList(db.Users, "AppEntityID", "PIN", websiteuser.AppEntityID);
            return View(websiteuser);
        }

        //
        // GET: /UserAccess/Edit/5

        public ActionResult Edit(int id = 0)
        {
            WebSiteUser websiteuser = db.WebSiteUsers.Single(w => w.WebSiteUserID == id);
            if (websiteuser == null)
            {
                return HttpNotFound();
            }
            ViewBag.WebLinkID = new SelectList(db.WebLinks, "WebLinkID", "Name", websiteuser.WebLinkID);
            ViewBag.WebSiteRoleID = new SelectList(db.UserRoles, "WebRoleID", "WebRole", websiteuser.WebSiteRoleID);
            ViewBag.AppEntityID = new SelectList(db.Users, "AppEntityID", "PIN", websiteuser.AppEntityID);
            return View(websiteuser);
        }

        //
        // POST: /UserAccess/Edit/5

        [HttpPost]
        public ActionResult Edit(WebSiteUser websiteuser)
        {
            if (ModelState.IsValid)
            {
                db.WebSiteUsers.Attach(websiteuser);
                db.ObjectStateManager.ChangeObjectState(websiteuser, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WebLinkID = new SelectList(db.WebLinks, "WebLinkID", "Name", websiteuser.WebLinkID);
            ViewBag.WebSiteRoleID = new SelectList(db.UserRoles, "WebRoleID", "WebRole", websiteuser.WebSiteRoleID);
            ViewBag.AppEntityID = new SelectList(db.Users, "AppEntityID", "PIN", websiteuser.AppEntityID);
            return View(websiteuser);
        }

        //
        // GET: /UserAccess/Delete/5

        public ActionResult Delete(int id = 0)
        {
            WebSiteUser websiteuser = db.WebSiteUsers.Single(w => w.WebSiteUserID == id);
            if (websiteuser == null)
            {
                return HttpNotFound();
            }
            return View(websiteuser);
        }

        //
        // POST: /UserAccess/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            WebSiteUser websiteuser = db.WebSiteUsers.Single(w => w.WebSiteUserID == id);
            db.WebSiteUsers.DeleteObject(websiteuser);
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