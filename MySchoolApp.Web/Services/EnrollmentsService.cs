using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using MySchoolApp.Web.Data;

namespace MySchoolApp.Web.Services
{
    public class EnrollmentsService : IEnrollmentsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EnrollmentsService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Models.Enrollments.EnrollmentIndexVM>> GetAllEnrollmentsAsync()
        {
            var applicationDbContext = _context.Enrollments.Include(e => e.CourseSection).Include(e => e.Student);
            var data = await applicationDbContext.ToListAsync();

            var viewData = _mapper.Map<List<Models.Enrollments.EnrollmentIndexVM>>(data);
            return viewData;
        }

        public async Task<T?> Get<T>(int id) where T : class
        {
            var enrollment = await _context.Enrollments
                .Include(e => e.CourseSection)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrollment == null)
            {
                return null;
            }
            var viewData = _mapper.Map<T>(enrollment);
            return viewData;
        }

        public async Task Remove(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Edit(Models.Enrollments.EnrollmentEditVM enrollmentEditVM)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentEditVM);
            _context.Update(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task Create(Models.Enrollments.EnrollmentCreateVM enrollmentCreateVM)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentCreateVM);
            _context.Add(enrollment);
            await _context.SaveChangesAsync();
        }

        public void UpdateLists(ViewDataDictionary viewData, int courseSectionId, int studentId)
        {
            viewData["CourseSectionId"] = new SelectList(_context.CourseSections.Select(c => new { c.Id, SectonName = c.SectionNumber + " " + c.Semester }), "Id", "SectonName", courseSectionId);
            viewData["StudentId"] = new SelectList(_context.Students.Select(s => new { s.Id, FullName = s.FirstName + " " + s.LastName }), "Id", "FullName", studentId);
        }

        public bool EnrollmentExists(int id)
        {
            return _context.Enrollments.Any(e => e.Id == id);
        }
    }
}
