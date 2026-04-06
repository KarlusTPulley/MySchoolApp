namespace MySchoolApp.Web.Models.Students
{
    public class StudentIndexVM
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }
    }
}
