using AutoMapper;
using MySchoolApp.Web.Data;
using Microsoft.EntityFrameworkCore;
using MySchoolApp.Web.Models.Courses;

//Karlus: you can convert this namespace to scope namespace by adding the ';'
//if we remove the semicolon the curly breaces will be re-added.
namespace MySchoolApp.Web.Services;

public class CoursesService : ICoursesService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CoursesService(ApplicationDbContext context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    public async Task<List<Models.Courses.CoursesIndexVM>> GetAllCoursesAsync()
    {
        var data = await _context.Courses.ToListAsync();

        var viewData = _mapper.Map<List<Models.Courses.CoursesIndexVM>>(data);

        return viewData;
    }

    public async Task<T?> Get<T>(int id) where T : class
    {
        var data = await _context.Courses
            .FirstOrDefaultAsync(m => m.Id == id);
        if (data == null)
        {
            return null;
        }
        var viewData = _mapper.Map<T>(data);
        return viewData;
    }

    public async Task Remove(int id)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(m => m.Id == id);
        if (course != null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Edit(CourseEditVM courseEditVM)
    {
        var course = _mapper.Map<Course>(courseEditVM);
        _context.Update(course);
        await _context.SaveChangesAsync();
    }

    public async Task Create(CourseCreateVM courseCreateVM)
    {
        var course = _mapper.Map<Course>(courseCreateVM);
        _context.Add(course);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CourseExists(int id)
    {
        return await _context.Courses.AnyAsync(e => e.Id == id);
    }

    public async Task<bool> CourseNameExists(string courseCode)
    {
        var lowercaseName = courseCode.ToLower();
        return await _context.Courses.AnyAsync(e => e.CourseCode.ToLower().Equals(lowercaseName));
    }

    public async Task<bool> CourseNameExistsForEcit(CourseEditVM courseEditVM)
    {
        var lowercaseName = courseEditVM.CourseName.ToLower();
        return await _context.Courses.AnyAsync(e => e.CourseCode.ToLower().Equals(lowercaseName)
            && e.Id != courseEditVM.Id);
    }
}
