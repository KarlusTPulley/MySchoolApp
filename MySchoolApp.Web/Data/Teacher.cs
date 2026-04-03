using System.ComponentModel.DataAnnotations.Schema;

namespace MySchoolApp.Web.Data
{
    public class Teacher
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public required string FirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public required string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        public ICollection<CourseSection>? CourseSections { get; set; }
    }
}
