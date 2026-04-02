using System.ComponentModel.DataAnnotations.Schema;

namespace MySchoolApp.Web.Data
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int CourseSectionId { get; set; }
        public CourseSection? CourseSection { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Grade { get; set; } // "A", "B+", etc.
    }
}
