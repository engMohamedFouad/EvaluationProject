using SchoolPerfectProject.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using SchoolPerfectProject.Models;

namespace SchoolPerfectProject.Controllers
{
    public class StudentController : Controller
    {
        MySchoolEntities6 m = new MySchoolEntities6();

        public ActionResult Index(string Search, int? page)
        {
            if(Search==null||Search==" "|| Search == ""||!m.Student.Any(x=>x.SName==Search))
            {
                return View(m.Student.ToList().ToPagedList(page ?? 1, 4));
            }
            else 
            {
                return View(m.Student.Where(x => x.SName == Search).ToList().ToPagedList(page ?? 1, 4));
            }

        }

        [HttpGet]
        public ActionResult Registration()
        {
            ViewBag.faculty = new SelectList(m.Faculty, "FID", "FName");
            return View();
        }
        //for take the data and make ajax operation
        public JsonResult GetDepartmentList(int FID)
        {
            m.Configuration.ProxyCreationEnabled = false;
            List<Department> d = m.Department.Where(x => x.FID == FID).ToList();
            return Json(d,JsonRequestBehavior.AllowGet);
        }
        //to save data of new user
        [HttpPost]
        public ActionResult Registration(Student stud)
        {
            if(m.Student.Any(x=>x.SName==stud.SName))
            {
                ModelState.AddModelError("SName", "UserName is Already in use");
            }
            if (ModelState.IsValid)
            {
                m.Student.Add(stud);
                m.SaveChanges();
                return RedirectToAction("Index");
            }
            else { 
            ViewBag.faculty = new SelectList(m.Faculty, "FID", "FName");
            return View(stud);
            }
        }
        public JsonResult IsUserNameAvailable(String SName)
        {
            return Json(!m.Student.Any(x => x.SName == SName), JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.faculty = new SelectList(m.Faculty, "FID", "FName");
            Student s = m.Student.Where(x => x.SID == id).Single();
            ViewBag.Department= new SelectList(m.Department.Where(x=>x.FID==s.FID), "DID", "DName");

            return View(s);
        }
        [HttpPost]
        public ActionResult Update(Student stud)
        {
            if(ModelState.IsValid)
            { 
                m.Entry(stud).State = System.Data.Entity.EntityState.Modified;
                m.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.faculty = new SelectList(m.Faculty, "FID", "FName");
                ViewBag.Department = new SelectList(m.Department.Where(x => x.FID == stud.FID), "DID", "DName");
                return View();
            }

        }
        [HttpGet]
        public ActionResult Detail()
        {
            Student s = new Student();
            return View(s);
        }

        
        public ActionResult Login()
        {
            Student s = new Student();
            return View(s);
        }
        [HttpPost]
        public ActionResult Login(Student s)
        {
            Student student = m.Student.Where(x => x.SName == s.SName && x.Password == s.Password).FirstOrDefault();
            if(student!=null)
            {
                 Session["student"]=student.SName;
                ViewData["o"] = Session["student"];
                ViewBag.st = student;
                return View("Detail",student);
            }
            else { 
                return View();
            }
        }
        //to distroy session
        public ActionResult Logout()
        {
           if( Session["student"]!=null)
            { 
                Session.Abandon();
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Detail");
            }
            
        }

        public ActionResult Delete(int id)
        {
            Student s = m.Student.Where(x => x.SID == id).FirstOrDefault();
                m.Student.Remove(s);
                m.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}