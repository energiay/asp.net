using AspNet.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AspNet.Controllers
{
    public class HomeController : Controller
    {

        


        public ActionResult Index(ApplicationDbContext context)
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var id = User.Identity.GetUserId();
                var currUser = userManager.FindById( id );

                ViewData["Age"] = currUser.Age;
                ViewData["MyEmail"] = currUser.MyEmail;
                ViewData["Pol"] = currUser.Pol;
            }

            return View();
        }

        public ActionResult AjaxTest()
        {
            TempData["str"] = "123456789";
            return View();
        }

        public PartialViewResult _StrTest (string str = "123456789", int a=0, int b=8)
        {
            ViewBag.str1 = str;
            ViewBag.a = a;
            ViewBag.b = b;
            return PartialView();
        }


    }
}