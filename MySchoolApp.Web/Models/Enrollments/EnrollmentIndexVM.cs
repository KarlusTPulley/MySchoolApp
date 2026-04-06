using MySchoolApp.Web.Data;

namespace MySchoolApp.Web.Models.Enrollments
{
    public class EnrollmentIndexVM
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int CourseSectionId { get; set; }
        public Data.CourseSection? CourseSection { get; set; }

        public string Grade { get; set; } // "A", "B+", etc.
    }
}
