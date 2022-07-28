using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab3.NetCoreLec3.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int deptID { get; set; }
        [Required]
        public string departmentName { get; set; }
        public Department()
        {
            students = new HashSet<Student>();
            courses=new HashSet<Course>();
        }
        ICollection<Student> students { get; set; }
        ICollection<Course> courses { get; set; }
    }
}
