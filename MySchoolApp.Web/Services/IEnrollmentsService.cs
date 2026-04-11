using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MySchoolApp.Web.Models.Enrollments;

namespace MySchoolApp.Web.Services
{
    public interface IEnrollmentsService
    {
        Task Create(EnrollmentCreateVM enrollmentCreateVM);
        Task Edit(EnrollmentEditVM enrollmentEditVM);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<EnrollmentIndexVM>> GetAllEnrollmentsAsync();
        Task Remove(int id);
        void UpdateLists(ViewDataDictionary viewData, int courseSectionId, int studentId);

        bool EnrollmentExists(int id);
    }
}