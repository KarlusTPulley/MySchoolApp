using System.ComponentModel.DataAnnotations.Schema;

namespace MySchoolApp.Web.Models.Courses
{
    public class CourseDeleteVM
    {
        public int Id { get; set; }

        public string CourseCode { get; set; } // e.g. "MATH101"

        public string Title { get; set; }

        [NotMapped]
        public string CourseName => $"{CourseCode} {Title}";
        public int Credits { get; set; }
    }
}
