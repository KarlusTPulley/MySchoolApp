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
            CreateMap<Teacher, TeacherIndexVM>();
            CreateMap<TeacherCreateVM, Teacher>();
            CreateMap<Teacher, TeacherDeleteVM>();
            CreateMap<Teacher, TeacherDetailsVM>();
            CreateMap<TeacherEditVM, Teacher>().ReverseMap();

            CreateMap<Course, CoursesIndexVM>();
            CreateMap<Course, CourseDeleteVM>();
            CreateMap<Course, CourseDetailsVM>();
            CreateMap<CourseCreateVM, Course>();
            CreateMap<CourseEditVM, Course>().ReverseMap();

            CreateMap<CourseSection, CourseSectionIndexVM>();
            CreateMap<CourseSection, CourseSectionDetailsVM>();
            CreateMap<CourseSection, CourseSectionEditVM>().ReverseMap();
            CreateMap<CourseSectionCreateVM, CourseSection>();
            CreateMap<CourseSection, CourseSectionDeleteVM>();

            CreateMap<Enrollment, EnrollmentIndexVM>();
            CreateMap<Enrollment, EnrollmentDetailsVM>();
            CreateMap<EnrollmentCreateVM, Enrollment>();
            CreateMap<EnrollmentEditVM, Enrollment>().ReverseMap();
            CreateMap<Enrollment, EnrollmentDeleteVM>();

            CreateMap<Student, StudentIndexVM>();
            CreateMap<StudentCreateVM, Student>();
            CreateMap<Student, StudentDeleteVM>();
            CreateMap<Student, StudentDetailsVM>();
            CreateMap<StudentEditVM, Student>().ReverseMap();
        }
    }
}
