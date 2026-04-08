using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySchoolApp.Web.Models.Teachers
{
    public class TeacherCreateVM
    {
        [Required]
        [Length(3, 50)]
        public required string FirstName { get; set; }

        [Required]
        [Length(3, 50)]
        public required string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [Length(7, 100)]
        public string Email { get; set; }
    }
}
