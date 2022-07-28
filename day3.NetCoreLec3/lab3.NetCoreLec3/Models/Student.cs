using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lab3.NetCoreLec3.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "please enter your name")]
        [StringLength(50,MinimumLength =3)]
        public string name { get; set; }
        //string عشان هو بيعملها لأي حاجة غير  required مش لازم احط
        [Range(20,35)]
        public int age { get; set; }
        [Required(ErrorMessage ="upload image please")]
        [NotMapped]
        public IFormFile image { get; set; }
        [Display(Name ="Upload image")]
        public string imagepath { get; set; }
        public string  Password { get; set; }
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [NotMapped]
        public string CPassword { get; set; }
        [ForeignKey("Department")]
        public int DeptID { get; set; }
        //navigation property
        public  Department Department { get; set; }
        public Student()
        {
            studentCourses = new HashSet<StudentCourse>();
        }
        ICollection<StudentCourse> studentCourses { get; set; }
    }
}
