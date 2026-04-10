using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySchoolApp.Web.Data;
using MySchoolApp.Web.Models.Courses;
using MySchoolApp.Web.Services;

namespace MySchoolApp.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICoursesService _coursesService;

        public CoursesController(ICoursesService coursesService)
        {
            _coursesService = coursesService;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var viewData = await _coursesService.GetAllCoursesAsync();
            return View(viewData);
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _coursesService.Get<CourseDetailsVM>(id.Value);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateVM courseCreateVM)
        {
            if(await _coursesService.CourseNameExists(courseCreateVM.CourseCode))
            {
                ModelState.AddModelError(nameof(courseCreateVM.CourseCode), "Course already exists");
            }

            if (ModelState.IsValid)
            {
                await _coursesService.Create(courseCreateVM);
                return RedirectToAction(nameof(Index));
            }
            return View(courseCreateVM);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewData = await _coursesService.Get<CourseEditVM>(id.Value);
            if (viewData == null)
            {
                return NotFound();
            }

            return View(viewData);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseEditVM courseEditVM)
        {
            if (id != courseEditVM.Id)
            {
                return NotFound();
            }

            if (await _coursesService.CourseNameExistsForEcit(courseEditVM))
            {
                    ModelState.AddModelError(nameof(courseEditVM.CourseCode), "Course already exists");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _coursesService.Edit(courseEditVM);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _coursesService.CourseExists(courseEditVM.Id))
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
            return View(courseEditVM);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewData = await _coursesService.Get<CourseDeleteVM>(id.Value);

            if (viewData == null)
            {
                return NotFound();
            }

            return View(viewData);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _coursesService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
