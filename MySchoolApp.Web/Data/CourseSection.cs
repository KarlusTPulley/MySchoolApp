using System.ComponentModel.DataAnnotations.Schema;

namespace MySchoolApp.Web.Data
{
    public class CourseSection
    {
        public int Id { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string SectionNumber { get; set; } // "001", "002"

        [Column(TypeName = "nvarchar(50)")]
        public string Semester { get; set; } // "Fall 2026"

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
