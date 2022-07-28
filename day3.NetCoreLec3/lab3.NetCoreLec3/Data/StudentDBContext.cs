using lab3.NetCoreLec3.Models;
using Microsoft.EntityFrameworkCore;

namespace lab3.NetCoreLec3.Data
{
    public class StudentDBContext:DbContext
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<StudentCourse> studentCourses { get; set; }
        
        public StudentDBContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-04LM1KF\\SQLEXPRESS;Database=ITIDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //both of them is composied primary key
            modelBuilder.Entity<StudentCourse>().HasKey(a => new
            {
                a.Sid,
                a.CID
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
