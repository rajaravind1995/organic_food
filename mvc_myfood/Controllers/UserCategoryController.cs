using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace mvc_myfood.Controllers
{
    public class UserCategoryController : Controller
    {
        myfoodEntities _con = new myfoodEntities();
        // GET: UserCategory
        public ActionResult Index()
        {
            var listofData = _con.categories.ToList();
            return View(listofData);
        }

        //public ActionResult Getproduct1()
        //{
        //    return View();
        //}
        public ActionResult Getproduct1()
        {
            //var listofData = _con.products.OrderByDescending(x => x.id).Where(x => x.category_id == id);
            //return View(listofData);

            using (var db = new myfoodEntities())
            {
                var d = db.categories.ToList();
                return View(d);
            }

            //var listofData = _con.categories.ToList();
            //return View(listofData);
        }

    }
}