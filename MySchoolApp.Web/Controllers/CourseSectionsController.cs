using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySchoolApp.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchoolApp.Web.Controllers
{
    public class CourseSectionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CourseSectionsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: CourseSections
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CourseSections.Include(c => c.Course).Include(c => c.Teacher);
            var data = await applicationDbContext.ToListAsync();
            var viewData = _mapper.Map<List<Models.CourseSection.CourseSectionIndexVM>>(data);
            return View(viewData);
        }

        // GET: CourseSections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseSection = await _context.CourseSections
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseSection == null)
            {
                return NotFound();
            }

            return View(courseSection);
        }

        // GET: CourseSections/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses.Select(c => new {c.Id, c.CourseName}), "Id", "CourseName");
            ViewData["TeacherId"] = new SelectList(_context.Teachers.Select(t => new { t.Id, t.FullName} ), "Id", "FullName");
            return View();
        }

        // POST: CourseSections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseId,TeacherId,SectionNumber,Semester")] CourseSection courseSection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseSection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", courseSection.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", courseSection.TeacherId);
            return View(courseSection);
        }

        // GET: CourseSections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseSection = await _context.CourseSections.FindAsync(id);
            if (courseSection == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", courseSection.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", courseSection.TeacherId);
            return View(courseSection);
        }

        // POST: CourseSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseId,TeacherId,SectionNumber,Semester")] CourseSection courseSection)
        {
            if (id != courseSection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseSectionExists(courseSection.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", courseSection.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", courseSection.TeacherId);
            return View(courseSection);
        }

        // GET: CourseSections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseSection = await _context.CourseSections
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseSection == null)
            {
                return NotFound();
            }

            return View(courseSection);
        }

        // POST: CourseSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseSection = await _context.CourseSections.FindAsync(id);
            if (courseSection != null)
            {
                _context.CourseSections.Remove(courseSection);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseSectionExists(int id)
        {
            return _context.CourseSections.Any(e => e.Id == id);
        }
    }
}
