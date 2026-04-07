using AutoMapper;
using MySchoolApp.Web.Data;
using MySchoolApp.Web.Models.Teachers;
using MySchoolApp.Web.Models.Courses;
using MySchoolApp.Web.Models.CourseSection;
using MySchoolApp.Web.Models.Enrollments;
using MySchoolApp.Web.Models.Students;

namespace MySchoolApp.Web.MappingProfiles
{
    public class SchoolMappingProfile : Profile
    {
        public SchoolMappingProfile()
        {
            CreateMap<Teacher, IndexVM>();
            CreateMap<Course, CoursesIndexVM>();
            CreateMap<CourseSection, CourseSectionIndexVM>();
            CreateMap<CourseSection, CourseSectionDetailsVM>();
            CreateMap<Enrollment, EnrollmentIndexVM>();
            CreateMap<Enrollment, EnrollmentDetailsVM>();
            CreateMap<Student, StudentIndexVM>();
        }
    }
}
