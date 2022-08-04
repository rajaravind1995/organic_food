using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace mvc_myfood.Controllers
{
   
    public class HomeController : Controller
    {
        myfoodEntities _con = new myfoodEntities();

        public object DefaultAuthenticationTypes { get; private set; }
        public object Authenticate { get; private set; }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Home
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(customer model)
        {
            if (ModelState.IsValid)
            {
                using (var databaseContext = new myfoodEntities())
                {
                    customer reglog = new customer();
                    reglog.name = model.name;
                    reglog.email = model.email;
                    reglog.phone = model.phone;
                    reglog.password = model.password;
                    databaseContext.customers.Add(reglog);
                    databaseContext.SaveChanges();
                }
                ViewBag.Message = "Customer Details Saved";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Login(customer model)
        {
            if (ModelState.IsValid)
            {
                var isValidUser = IsValidUser(model);
                if (isValidUser != null)
                {
                    // FormsAuthentication.SetAuthCookie(model.email, false);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Wrong Username and password combination !");
                }
            }
            return View();
        }
        public customer IsValidUser(customer model)
        {
            using (var dataContext = new myfoodEntities())
            {
                customer user = dataContext.customers.Where(query => (query.email.Equals(model.email) || query.phone.Equals(model.phone)) && query.password.Equals(model.password)).SingleOrDefault();
                if (user == null)
                    return null;
                else
                    return user;
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Contents.RemoveAll();
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");

        }
    }
}