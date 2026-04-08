using MySchoolApp.Web.Data;
using System.ComponentModel.DataAnnotations;

namespace MySchoolApp.Web.Models.CourseSection
{
    public class CourseSectionCreateVM
    {
        public int CourseId { get; set; }

        public int TeacherId { get; set; }

        [Required]
        [Length(3, 20)]
        public string SectionNumber { get; set; } // "001", "002"

        [Required]
        [Length(6, 50)]
        public string Semester { get; set; } // "Fall 2026"
    }
}
