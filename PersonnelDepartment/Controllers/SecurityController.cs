using PersonnelDepartment.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonnelDepartment.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        PersonnelDbEntities db = new PersonnelDbEntities();
       // [Route("")]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User usr)
        {
            var user = db.User.FirstOrDefault(x => x.Name == usr.Name && x.Password == usr.Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Name, false);
                return RedirectToAction("Index", "Department");
            }
            else
            {
                ViewBag.Mesaj = "Invalid user or password";
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Security");
        }

    }
}
