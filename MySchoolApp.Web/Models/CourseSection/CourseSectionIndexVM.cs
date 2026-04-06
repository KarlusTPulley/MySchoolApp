using MySchoolApp.Web.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySchoolApp.Web.Models.CourseSection
{
    public class CourseSectionIndexVM
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
