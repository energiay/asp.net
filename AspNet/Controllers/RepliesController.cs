using AspNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AspNet.Controllers
{
    public class RepliesController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        /*
        // GET: Replies
        public ActionResult Index()
        {
            return View();
        }
        */

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int? Id, [Bind(Include = "Id,MessageId,Text,PublishDate")]Reply reply)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    reply.MessageId = (int)Id;
                    reply.PublishDate = DateTime.Now;
                    db.Replies.Add(reply);
                    db.SaveChanges();

                    return RedirectToAction("Details", "Messages", new { id = Id });
                }
            }

            return View();

         }

        public ActionResult Delete(int? Id)
        {
            if(Id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply reply = db.Replies.Find(Id);
            if(reply == null)
            {
                return HttpNotFound();
            }
            TempData["id"] = reply.Message.Id;
            return View(reply);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            Reply reply = db.Replies.Find(Id);
            db.Replies.Remove(reply);
            db.SaveChanges();

            return RedirectToAction("Details", "Messages", new { id = TempData["id"] });
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply reply = db.Replies.Find(Id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            TempData["id"] = reply.Message.Id;
            return View(reply);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,PublishDate,MessageId")]Reply reply)
        {
            if(ModelState.IsValid)
            {
                reply.MessageId = (int)TempData["id"];
                reply.PublishDate = DateTime.Now;
                db.Entry(reply).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Details", "Messages", new { id = TempData["id"] });
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