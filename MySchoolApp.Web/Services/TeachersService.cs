using AutoMapper;
using MySchoolApp.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace MySchoolApp.Web.Services;

public class TeachersService : ITeachersService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public TeachersService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Models.Teachers.TeacherIndexVM>> GetAllTeachersAsync()
    {
        var data = await _context.Teachers.ToListAsync();
        var viewData = _mapper.Map<List<Models.Teachers.TeacherIndexVM>>(data);
        return viewData;
    }

    public async Task<T?> Get<T>(int id) where T : class
    {
        var data = await _context.Teachers
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
        var teacher = await _context.Teachers.FirstOrDefaultAsync(m => m.Id == id);
        if (teacher != null)
        {
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Edit(Models.Teachers.TeacherEditVM teacherEditVM)
    {
        var teacher = _mapper.Map<Teacher>(teacherEditVM);
        _context.Update(teacher);
        await _context.SaveChangesAsync();
    }

    public async Task Create(Models.Teachers.TeacherCreateVM teacherCreateVM)
    {
        var teacher = _mapper.Map<Teacher>(teacherCreateVM);
        _context.Add(teacher);
        await _context.SaveChangesAsync();
    }

    public bool TeacherExists(int id)
    {
        return _context.Teachers.Any(e => e.Id == id);
    }
}
