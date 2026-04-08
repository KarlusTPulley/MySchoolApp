using System.ComponentModel.DataAnnotations;

namespace MySchoolApp.Web.Models.Courses
{
    public class CourseCreateVM
    {
        [Required]
        [Length(3, 20)]
        public string CourseCode { get; set; } // e.g. "MATH101"

        [Required]
        [Length(3, 50)]
        public string Title { get; set; }

        public int Credits { get; set; }
    }
}
