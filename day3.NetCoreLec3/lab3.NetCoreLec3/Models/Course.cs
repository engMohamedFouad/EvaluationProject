using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lab3.NetCoreLec3.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CID{ get; set; }
        [Required]
        public string CourseName { get; set; }
        public int LecHours { get; set; }
        public int LabHours { get; set; }
        public Course()
        {
            departments = new HashSet<Department>();
            studentCourses = new HashSet<StudentCourse>();
        }
        ICollection<Department> departments { get; set; }
        ICollection<StudentCourse> studentCourses { get; set; }
    }
}
