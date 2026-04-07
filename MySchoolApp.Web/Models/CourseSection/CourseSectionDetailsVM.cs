using MySchoolApp.Web.Data;

namespace MySchoolApp.Web.Models.CourseSection
{
    public class CourseSectionDetailsVM
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public Course? Course { get; set; }

        public int TeacherId { get; set; }

        public Teacher? Teacher { get; set; }

        public string SectionNumber { get; set; } // "001", "002"

        public string Semester { get; set; } // "Fall 2026"
    }
}
