using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySchoolApp.Web.Models.Students
{
    public class StudentCreateVM
    {
        [Required]
        [Length(2, 50)]
        public required string FirstName { get; set; }

        [Required]
        [Length(2, 50)]
        public required string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        [Length(7, 100)]
        public string Email { get; set; }
    }
}
