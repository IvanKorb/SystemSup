using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemSup.Models;
using Microsoft.EntityFrameworkCore;

namespace SystemSup.Controllers
{
    //[Authorize (Roles = "Администратор")]
    public class ServiceController : Controller
    {
       TechSupDbContext db = new TechSupDbContext();

        [HttpGet]
        public ActionResult Departments()
        {
            ViewBag.Departments = db.Departments;
            return View();
        }
        //Добавление отдела с отображением
        [HttpPost]
        public ActionResult Departments(Department depo)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(depo);
                db.SaveChanges();
            }

            ViewBag.Departments = db.Departments;
            return View(depo);
        }
        //Удаление отдела по Id
        public ActionResult DeleteDepartment(int id)
        {
            Department depo = db.Departments.Find(id);
            db.Departments.Remove(depo);
            db.SaveChanges();
            return RedirectToAction("Departments");
        }

        [HttpGet]
        public ActionResult Activ()
        {
            ViewBag.Activs = db.Activs.Include(s => s.Department);
            ViewBag.Departments = new SelectList(db.Departments, "Id", "name");
            return View();
        }

        [HttpPost]
        public ActionResult Activ(Activ activ)
        {
            if (ModelState.IsValid)
            {
                db.Activs.Add(activ);
                db.SaveChanges();
            }

            ViewBag.Activs = db.Activs.Include(s => s.Department);
            ViewBag.Departments = new SelectList(db.Departments, "Id", "Name");

            return View(activ);
        }

        //удаление кабинет по ID
        public ActionResult DeleteActiv(int id)
        {
            Activ activ = db.Activs.Find(id);
            db.Activs.Remove(activ);
            db.SaveChanges();
            return RedirectToAction("Activ");
        }

        //отображение категорий
        [HttpGet]
        public ActionResult Categories()
        {
            ViewBag.Categories = db.Categories;
            return View();
        }

        //добавление категорий
        [HttpPost]
        public ActionResult Categories(Category cat)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(cat);
                db.SaveChanges();
            }

            ViewBag.Categories = db.Categories;
            return View(cat);
        }

        //удаление категории по ID
        public ActionResult DeleteCategory(int id)
        {
            Category cat = db.Categories.Find(id);
            db.Categories.Remove(cat);
            db.SaveChanges();
            return RedirectToAction("Categories");
        }

    }
}