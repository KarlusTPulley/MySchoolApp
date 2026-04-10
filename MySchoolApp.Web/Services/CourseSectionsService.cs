using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using MySchoolApp.Web.Data;
using MySchoolApp.Web.Models.Courses;
using MySchoolApp.Web.Models.CourseSection;

//Karlus: you can convert this namespace to scope namespace by adding the ';'
//if we remove the semicolon the curly breaces will be re-added.
namespace MySchoolApp.Web.Services;

public class CourseSectionsService : ICourseSectionsService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CourseSectionsService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CourseSectionIndexVM>> GetAllCoursesAsync()
    {
        var applicationDbContext = _context.CourseSections.Include(c => c.Course).Include(c => c.Teacher);
        var data = await applicationDbContext.ToListAsync();
        var viewData = _mapper.Map<List<CourseSectionIndexVM>>(data);

        return viewData;
    }

    public async Task<T?> Get<T>(int id) where T : class
    {
        var courseSection = await _context.CourseSections
            .Include(c => c.Course)
            .Include(c => c.Teacher)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (courseSection == null)
        {
            return null;
        }
        var viewData = _mapper.Map<T>(courseSection);
        return viewData;
    }

    public async Task Remove(int id)
    {
        var courseSection = await _context.CourseSections.FirstOrDefaultAsync(m => m.Id == id);
        if (courseSection != null)
        {
            _context.CourseSections.Remove(courseSection);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Edit(CourseSectionEditVM courseSectionEditVM)
    {
        var courseSection = _mapper.Map<CourseSection>(courseSectionEditVM);
        _context.Update(courseSection);
        await _context.SaveChangesAsync();
    }

    public async Task Create(CourseSectionCreateVM courseSectionCreateVM)
    {
        var course = _mapper.Map<CourseSection>(courseSectionCreateVM);
        _context.Add(course);
        await _context.SaveChangesAsync();
    }

    public void UpdateLists(ViewDataDictionary viewData)
    {
        viewData["CourseId"] = new SelectList(_context.Courses.Select(c => new { c.Id, c.CourseName }), "Id", "CourseName");
        viewData["TeacherId"] = new SelectList(_context.Teachers.Select(t => new { t.Id, t.FullName }), "Id", "FullName");
    }

    public bool CourseSectionExists(int id)
    {
        return _context.CourseSections.Any(e => e.Id == id);
    }
}
