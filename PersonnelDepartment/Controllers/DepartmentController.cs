using PersonnelDepartment.Models.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace PersonnelDepartment.Controllers
{
    [Authorize]//koruma altına alma
    public class DepartmentController : Controller
    {
        // GET: Departman
        /*   [Route("")]
           [Route("index")]
          */

        PersonnelDbEntities db = new PersonnelDbEntities();

        public ActionResult Index()
        {
            var model = db.Department.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("DepartmentF", new Department());
        }
        //csrF saldırısı
        [ValidateAntiForgeryToken]//urlden gelen sahte girişleri engellemek için
        public ActionResult Create(Department dep)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmentF");
            }
            if (dep.Id == 0)
            {
                db.Department.Add(dep);
            }
            else
            {
                var update = db.Department.Find(dep.Id);
                if (update == null)
                {
                    return HttpNotFound();
                }
                update.Name = dep.Name;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var model = db.Department.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("DepartmentF", model);
        }
        public ActionResult Delete(int id)
        {
            var model = db.Department.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            db.Department.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}