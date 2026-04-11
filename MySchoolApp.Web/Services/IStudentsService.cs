using MySchoolApp.Web.Models.Students;

namespace MySchoolApp.Web.Services
{
    public interface IStudentsService
    {
        Task Create(StudentCreateVM studentCreateVM);
        Task Edit(StudentEditVM studentEditVM);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<StudentIndexVM>> GetAllStudentsAsync();
        Task Remove(int id);

        bool StudentExists(int id);
        Task<bool> CheckIfEnrollmentExist(int id);
    }
}