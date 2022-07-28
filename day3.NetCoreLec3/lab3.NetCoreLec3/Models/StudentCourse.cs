using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab3.NetCoreLec3.Models
{
    public class StudentCourse
    { //should add the sid,CID composed primary Key 
        [ForeignKey("student")]
        public int Sid { get; set; }
        [ForeignKey("course")]
        public int CID { get; set; }
        [Range(0,100)]
        public int degree { get; set; }
        public Student student { get; set; }
        public Course course { get; set; }
        
    }
}
