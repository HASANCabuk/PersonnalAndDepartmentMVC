using PersonnelDepartment.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PersonnelDepartment.ViewModels;

namespace PersonnelDepartment.Controllers
{

    public class PersonnelController : Controller
    {
        // GET: Personnel
        PersonnelDbEntities db = new PersonnelDbEntities();

        public ActionResult Index()
        {
            var model = db.Personnel.Include(x => x.Department).ToList();//Eager Loading Lazy Loading
                                                                         // var model = db.Personnel.ToList();
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "A")]//koruma altına alma
        public ActionResult Create()
        {
            var model = new PersonnelFViewModels()
            {
                Departments = db.Department.ToList(),
                Personnel = new Personnel()

            };
            return View("PersonnelF", model);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(PersonnelFViewModels per)
        {
            if (!ModelState.IsValid)
            {
                var model = new PersonnelFViewModels()
                {
                    Departments = db.Department.ToList(),
                    Personnel = per.Personnel
                };
                return View("PersonnelF", model);
            }
            if (per.Personnel.Id == 0)
            {
                db.Personnel.Add(per.Personnel);
            }
            else
            {
                /* var model = new Personnel();// { DepartmentId = per.Personnel.DepartmentId };
                 model = per.Personnel;*/
                //dbCtx.Entry(stud).State=System.Data.Entity.EntityState.Modified;
                db.Entry(per.Personnel).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*  public ActionResult Create(Personnel per)
          {
              if (per.Id == 0)
              {
                  db.Personnel.Add(per);
              }
              else
              {
                  //dbCtx.Entry(stud).State=System.Data.Entity.EntityState.Modified;
                  db.Entry(per).State = System.Data.Entity.EntityState.Modified;
              }
              db.SaveChanges();
              return RedirectToAction("Index");
          }*/
        public ActionResult Update(int id)
        {
            var model = new PersonnelFViewModels()
            {
                Departments = db.Department.ToList(),
                Personnel = db.Personnel.Find(id)
            };

            if (model == null)
            {
                return HttpNotFound();
            }

            return View("PersonnelF", model);
        }
        public ActionResult Delete(int id)
        {
            var model = db.Personnel.Find(id);


            if (model == null)
            {
                return HttpNotFound();
            }
            db.Personnel.Remove(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}