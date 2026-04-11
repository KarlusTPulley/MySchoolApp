using MySchoolApp.Web.Models.Teachers;

namespace MySchoolApp.Web.Services
{
    public interface ITeachersService
    {
        Task Create(TeacherCreateVM teacherCreateVM);
        Task Edit(TeacherEditVM teacherEditVM);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<TeacherIndexVM>> GetAllTeachersAsync();
        Task Remove(int id);
        bool TeacherExists(int id);
    }
}