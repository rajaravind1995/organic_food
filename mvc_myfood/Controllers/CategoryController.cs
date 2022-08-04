using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_myfood.Controllers
{   
    public class CategoryController : Controller
    {
        myfoodEntities _con = new myfoodEntities();
        // GET: Category
        public ActionResult Index()
        {
            var listofData = _con.categories.ToList();
            return View(listofData);
        }

        public ActionResult Category()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Category(category model)
        {
            if (ModelState.IsValid)
            {
                using (var databaseContext = new myfoodEntities())
                {
                    category cat = new category();
                    cat.category_name = model.category_name;
                    databaseContext.categories.Add(cat);
                    databaseContext.SaveChanges();
                }
                ViewBag.Message = "Category Details Saved";
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var data = _con.categories.Where(x => x.id == id).FirstOrDefault();
            _con.categories.Remove(data);
            _con.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _con.categories.Where(x => x.id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(category Model)
        {
            var data = _con.categories.Where(x => x.id == Model.id).FirstOrDefault();
            if (data != null)
            {
                data.category_name = Model.category_name;               
                _con.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var data = _con.categories.Where(x => x.id == id).FirstOrDefault();
            return View(data);
        }
    }
}