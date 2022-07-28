namespace lab3.NetCoreLec3.Models
{
    public interface IStudent
    {
        public List<Student> GetAllStudents();
        public Student getStudentByid(int id);
        public void create(Student s);
        public void updatestudent(Student stud);
        public void delete(Student s);
    }
}
