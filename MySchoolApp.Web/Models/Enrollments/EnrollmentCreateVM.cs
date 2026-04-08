using MySchoolApp.Web.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySchoolApp.Web.Models.Enrollments
{
    public class EnrollmentCreateVM
    {
        public int StudentId { get; set; }

        public int CourseSectionId { get; set; }

        [Length(1, 20)]
        public string Grade { get; set; } // "A", "B+", etc.
    }
}
