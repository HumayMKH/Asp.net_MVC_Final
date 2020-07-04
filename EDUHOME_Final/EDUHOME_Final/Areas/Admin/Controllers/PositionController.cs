using EDUHOME_Final.DAL;
using EDUHOME_Final.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EDUHOME_Final.Areas.Admin.Controllers
{
    public class PositionController : Controller
    {
        // GET: Admin/Position
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                List<Position> positions = db.Positions.ToList();
                return View(positions);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Position/Details
        public ActionResult Details(int id)
        {
            if (Session["Admin"] != null)
            {
                Position position = db.Positions.Find(id);
                return View(position);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Position/Create
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Create(Position position)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                db.Positions.Add(position);
                db.SaveChanges();

                return RedirectToAction("Index");
                }
                return View(position);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Position/Update
        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
                Position position = db.Positions.Find(id);
                if (position == null)
                {
                    return HttpNotFound();
                }              
                return View(position);
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Update(Position position)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                db.Entry(position).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
                }              
                return View(position);
            }
            return RedirectToAction("Login", "Login");
        }

        //Admin/Position/Delete
        public ActionResult Delete(int id)
        {
            if (Session["Admin"] != null)
            {
                Position position = db.Positions.Find(id);
                if (position == null)
                {
                    return HttpNotFound();
                }
                
                db.Positions.Remove(position);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Login");
        }  
    }
}