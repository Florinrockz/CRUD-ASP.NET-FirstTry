using CRUD_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_ASP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        //Get Users
        public ActionResult GetUsers()
        {
            using (Database1Entities dc = new Database1Entities())
            {
                var users = dc.Users.OrderBy(a => a.name).ToList();
                return Json(new { data = users }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            using(Database1Entities dc =new Database1Entities())
            {
                var v = dc.Users.Where(a => a.Id == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Save(User us)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using(Database1Entities dc=new Database1Entities())
                {
                    if (us.Id > 0)
                    {
                        //Edit data
                        var v = dc.Users.Where(a => a.Id == us.Id).FirstOrDefault();
                        if (v != null)
                        {
                            v.name = us.name;
                            v.email = us.email;
                            v.phone = us.phone;
                            v.country = us.country;
                            v.city = us.city;
                        }
                    }
                    else
                    {
                        //Save data
                        dc.Users.Add(us);
                    }
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status} };
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using(Database1Entities dc = new Database1Entities())
            {
                var v = dc.Users.Where(a => a.Id == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteUser(int id)
        {
            bool status = false;
            using(Database1Entities dc=new Database1Entities())
            {
                var v = dc.Users.Where(a => a.Id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.Users.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}