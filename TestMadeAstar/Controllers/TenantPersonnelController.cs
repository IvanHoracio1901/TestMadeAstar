using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMadeAstar.Models;

namespace TestMadeAstar.Controllers
{
    public class TenantPersonnelController : Controller
    {
        // GET: TenantPersonnel
        public ActionResult Index()
        {
            try
            {
                using (var db = new TestDemoAstarEntities())
                {
                    return View(db.TenantPersonnel.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult AddT()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddT(TenantPersonnel person)
        {
           
                try
            {
                using (var db = new TestDemoAstarEntities())
                {
                    person.DOB = DateTime.Now;
                    
                        db.TenantPersonnel.Add(person);
                        if (ModelState.IsValid)
                        {
                            db.SaveChanges();
                           
                        }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Error to add", ex);
                return View();
            }
        }
        public ActionResult EditT(int id)
        {
            try
            {
                using (var db = new TestDemoAstarEntities())
                {
                    TenantPersonnel person = db.TenantPersonnel.Where(a => a.TenantId == id).FirstOrDefault();
                    return View(person);
                }
            }
            catch (Exception ex)
            {
;
                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditT(TenantPersonnel person)
        {
            try
            {
                using (var db = new TestDemoAstarEntities())
                {
                    TenantPersonnel user = db.TenantPersonnel.Find(person.TenantId);
                    user.FirstName = person.FirstName;
                    user.MiddleName = person.MiddleName;
                    user.LastName = person.LastName;
                    user.GenderFk = person.GenderFk;
                    user.NickName = person.NickName;
                    user.PrefixID = person.PrefixID;
                    if (ModelState.IsValid)
                    {
                        db.SaveChanges();

                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Error to edit", ex);
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                using (var db = new TestDemoAstarEntities())
                {
                    TenantPersonnel person = db.TenantPersonnel.Find(id);
                    return View(person);
                }
            }
            catch (Exception ex)
            {
                ;
                throw;
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new TestDemoAstarEntities())
                {
                    TenantPersonnel person = db.TenantPersonnel.Find(id);
                    db.TenantPersonnel.Remove(person);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

    }
}