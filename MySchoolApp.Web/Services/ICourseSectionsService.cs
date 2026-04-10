using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MySchoolApp.Web.Models.CourseSection;

namespace MySchoolApp.Web.Services
{
    public interface ICourseSectionsService
    {
        Task Edit(CourseSectionEditVM courseSectionEditVM);
        Task Create(CourseSectionCreateVM courseSectionCreateVM);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<CourseSectionIndexVM>> GetAllCoursesAsync();
        Task Remove(int id);

        void UpdateLists(ViewDataDictionary viewData);
        bool CourseSectionExists(int id);
    }
}