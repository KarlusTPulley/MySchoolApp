using MySchoolApp.Web.Models.Courses;

namespace MySchoolApp.Web.Services
{
    public interface ICoursesService
    {
        Task<bool> CourseExists(int id);
        Task<bool> CourseNameExists(string courseCode);
        Task<bool> CourseNameExistsForEcit(CourseEditVM courseEditVM);
        Task Create(CourseCreateVM courseCreateVM);
        Task Edit(CourseEditVM courseEditVM);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<CoursesIndexVM>> GetAllCoursesAsync();
        Task Remove(int id);
    }
}