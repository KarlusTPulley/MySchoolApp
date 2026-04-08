using System.ComponentModel.DataAnnotations.Schema;

namespace MySchoolApp.Web.Models.Courses
{
    public class CourseEditVM
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string CourseCode { get; set; } // e.g. "MATH101"

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [NotMapped]
        public string CourseName => $"{CourseCode} {Title}";
        public int Credits { get; set; }
    }
}
