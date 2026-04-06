namespace MySchoolApp.Web.Models.Courses
{
    public class CoursesIndexVM
    {
        public int Id { get; set; }

        public string CourseCode { get; set; } // e.g. "MATH101"

        public string Title { get; set; }

        public int Credits { get; set; }
    }
}
