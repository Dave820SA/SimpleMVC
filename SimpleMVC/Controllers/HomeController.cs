using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleMVC.Models;
using System.Web.Script.Serialization;

namespace SimpleMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //string helpTextKey = Request["HelpTextKey"];
            
            ViewBag.HelpText = GetHelpTextByKey("email");
            return View();
        }

        
        private string GetHelpTextByKey (string key)
        {

            tblHelpText db = new tblHelpText();
            var mykey = from k in db.HelpText
                    where db.HelpTextKey == key
                    select k.ToString();

            return mykey.ToString();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
