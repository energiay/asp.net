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


    }
}