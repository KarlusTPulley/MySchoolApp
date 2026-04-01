using System.ComponentModel.DataAnnotations.Schema;

namespace MySchoolApp.Web.Data
{
    public class Course
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string CourseCode { get; set; } // e.g. "MATH101"

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<CourseSection> Sections { get; set; }
    }
}
