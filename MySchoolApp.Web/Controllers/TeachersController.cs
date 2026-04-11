using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySchoolApp.Web.Data;
using MySchoolApp.Web.Models.Teachers;
using MySchoolApp.Web.Services;

namespace MySchoolApp.Web.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeachersService _teachersService; 

        public TeachersController(ITeachersService teachersService)
        {
            _teachersService = teachersService;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            var viewData = await _teachersService.GetAllTeachersAsync();
            return View(viewData);
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherDetailsVM = await _teachersService.Get<TeacherDetailsVM>(id.Value);
            if (teacherDetailsVM == null)
            {
                return NotFound();
            }

            return View(teacherDetailsVM);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherCreateVM teacherCreateVM)
        {
            if (ModelState.IsValid)
            {
                await _teachersService.Create(teacherCreateVM);
                return RedirectToAction(nameof(Index));
            }
            return View(teacherCreateVM);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherEditVM = await _teachersService.Get<TeacherEditVM>(id.Value);
            if (teacherEditVM == null)
            {
                return NotFound();
            }

            return View(teacherEditVM);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TeacherEditVM teacherEditVM)
        {
            if (id != teacherEditVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _teachersService.Edit(teacherEditVM);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_teachersService.TeacherExists(teacherEditVM.Id))
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
            return View(teacherEditVM);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherDeleteVM = await _teachersService.Get<TeacherDeleteVM>(id.Value);
            if (teacherDeleteVM == null)
            {
                return NotFound();
            }

            return View(teacherDeleteVM);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _teachersService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
