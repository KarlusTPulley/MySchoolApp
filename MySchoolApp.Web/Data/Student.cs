using System.ComponentModel.DataAnnotations.Schema;

namespace MySchoolApp.Web.Data
{
    public class Student
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public required string FirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public required string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
