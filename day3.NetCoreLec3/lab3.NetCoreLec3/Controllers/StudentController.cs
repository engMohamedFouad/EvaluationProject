using lab3.NetCoreLec3.Data;
using lab3.NetCoreLec3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab3.NetCoreLec3.Controllers
{
    public class StudentController : Controller
    {
        IStudent db;
        private StudentDBContext context;
        public StudentController(IStudent _db, StudentDBContext _context)
        {
            db=_db;
            context=_context;
        }
        public IActionResult Index()
        {
            List<Student> s= db.GetAllStudents();
            return View(s);
        }
        [HttpGet]
        public IActionResult create()
        {
            ViewBag.depts =new SelectList(context.departments.ToList(), "deptID", "departmentName");
            return View();
        }
        [HttpPost]
        public IActionResult create(Student s)
        {
            if (ModelState.IsValid) { 
            //add image to image folder
            string path = "./wwwroot/image/" + s.image.FileName;
            using (var item = new FileStream(path, FileMode.Create))
            {
                s.image.CopyTo(item);
            }
            //add student to the list
            s.imagepath = s.image.FileName;
            db.create(s);
            return RedirectToAction("Index");
            }
            else
            {
                return View(s);
            }
        }
        public IActionResult details(int id)
        {
            Student s = db.getStudentByid(id);
            if (s != null) { 
            return View(s);
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult saveimage(int id)
        {
            Student s = db.getStudentByid(id);
            if (s != null)
            {
                return File($"/image/{s.imagepath}", "image/jpeg", s.imagepath);
            }
            else
            {
                return NotFound();
            }
            // return File("/folder name/name of file with extention", "content file such as(text/plain)", "name of file with extention");
        }
        [HttpGet]
        public IActionResult update(int id)
        {
            Student s = db.getStudentByid(id);
            if (s != null)
            {
                ViewBag.depts = new SelectList(context.departments.ToList(), "deptID", "departmentName");
                return View(s);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult update(Student s)
        {
            //update image in folder
            string path = "./wwwroot/image/" + s.image.FileName;
            using (var item = new FileStream(path, FileMode.Create))
            {
                s.image.CopyTo(item);
            }
            //update student
            s.imagepath = s.image.FileName;
            db.updatestudent(s);
            return RedirectToAction("Index");
        }

        public IActionResult delete(int id)
        {
            Student s = db.getStudentByid(id);
            if (s != null)
            {
                db.delete(s);
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
