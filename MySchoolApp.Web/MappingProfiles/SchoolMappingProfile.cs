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
            CreateMap<TeacherCreateVM, Teacher>();
            CreateMap<Course, CoursesIndexVM>();
            CreateMap<CourseCreateVM, Course>();
            CreateMap<CourseEditVM, Course>().ReverseMap();
            CreateMap<CourseSection, CourseSectionIndexVM>();
            CreateMap<CourseSection, CourseSectionDetailsVM>();
            CreateMap<CourseSectionCreateVM, CourseSection>();
            CreateMap<Enrollment, EnrollmentIndexVM>();
            CreateMap<Enrollment, EnrollmentDetailsVM>();
            CreateMap<EnrollmentCreateVM, Enrollment>();
            CreateMap<Student, StudentIndexVM>();
            CreateMap<StudentCreateVM, Student>();
        }
    }
}
