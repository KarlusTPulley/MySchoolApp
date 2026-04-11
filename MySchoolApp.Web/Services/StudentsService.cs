using AutoMapper;
using MySchoolApp.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace MySchoolApp.Web.Services;

public class StudentsService : IStudentsService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public StudentsService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Models.Students.StudentIndexVM>> GetAllStudentsAsync()
    {
        var students = await _context.Students
            .Select(s => new Student
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                DateOfBirth = s.DateOfBirth,
                CanDelete = !s.Enrollments.Any()
            })
            .ToListAsync();

        return _mapper.Map<List<Models.Students.StudentIndexVM>>(students);
    }

    public async Task<T?> Get<T>(int id) where T : class
    {
        var student = await _context.Students
            .FirstOrDefaultAsync(m => m.Id == id);
        if (student == null)
        {
            return null;
        }
        return _mapper.Map<T>(student);
    }

    public async Task Remove(int id)
    {
        var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
        if (student != null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Edit(Models.Students.StudentEditVM studentEditVM)
    {
        var student = _mapper.Map<Student>(studentEditVM);
        _context.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task Create(Models.Students.StudentCreateVM studentCreateVM)
    {
        var student = _mapper.Map<Student>(studentCreateVM);
        _context.Add(student);
        await _context.SaveChangesAsync();
    }

    public bool StudentExists(int id)
    {
        return _context.Students.Any(e => e.Id == id);
    }

    public async Task<bool> CheckIfEnrollmentExist(int id)
    {
        return await _context.Enrollments.AnyAsync(e => e.StudentId == id);
    }
}
