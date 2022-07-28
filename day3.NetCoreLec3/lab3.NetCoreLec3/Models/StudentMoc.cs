using lab3.NetCoreLec3.Data;
using Microsoft.EntityFrameworkCore;

namespace lab3.NetCoreLec3.Models
{   
    public class StudentMoc:IStudent
    {
        List<Student> students = new List<Student>()
        {
            new Student (){id=1,name="mohamed",age=25,imagepath="f56699168.jpg",Password="123"},
            new Student (){id=2,name="ahmed",age=30,imagepath="f59039040.jpg",Password="321"},
            new Student (){id=3,name="ali",age=45,imagepath="f59039120.jpg",Password="567"}
        };
        //to return all student in the list
        public List<Student> GetAllStudents()
        {
            return students;
        }
        //to find student
        public Student getStudentByid(int id)
        {
            Student s = students.FirstOrDefault(a => a.id==id);
            return s;
        }
        public void create(Student s)
        {
            students.Add(s);
        }
        //to update student
        public void updatestudent(Student stud)
        {
            Student s = students.FirstOrDefault(a => a.id == stud.id);
            s.name = stud.name;
            s.age = stud.age;
            s.imagepath = stud.imagepath;
            s.Password = stud.Password;
        }
        //to delete student
        public void delete(Student s)
        {
            students.Remove(s);
        }
    }
    
    public class StudentDB : IStudent
    {
        StudentDBContext context;
        public StudentDB(StudentDBContext _context)
        {
            context = _context;
        }

        public void create(Student s)
        {
            context.students.Add(s);
            context.SaveChanges();
        }

        public void delete(Student s)
        {
            context.students.Remove(s);
            context.SaveChanges();
        }

        public List<Student> GetAllStudents()
        {
            //navigation propertyوانتا بتجيب البيانات هات معاك البيانات بتاعت ال 
            return context.students.Include(a => a.Department).ToList();
        }

        public Student getStudentByid(int id)
        {
            return context.students.FirstOrDefault(a => a.id == id);
        }

        public void updatestudent(Student stud)
        {
            context.students.Update(stud);
            context.SaveChanges();
        }
    }
}
