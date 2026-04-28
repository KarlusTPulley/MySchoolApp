using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySchoolApp.Web.Data;
using MySchoolApp.Web.Models.Courses;
using MySchoolApp.Web.Models.CourseSection;
using MySchoolApp.Web.Models.Enrollments;
using MySchoolApp.Web.Services;

namespace MySchoolApp.Web.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class EnrollmentsController : Controller
    {
        IEnrollmentsService _enrollmentsService;

        public EnrollmentsController(IEnrollmentsService enrollmentsService)
        {
            _enrollmentsService = enrollmentsService;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            var viewData = await _enrollmentsService.GetAllEnrollmentsAsync();
            return View(viewData);
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewData = await _enrollmentsService.Get<EnrollmentDetailsVM>(id.Value);
            if (viewData == null)
            {
                return NotFound();
            }

            return View(viewData);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            _enrollmentsService.UpdateLists(ViewData, 0, 0);
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EnrollmentCreateVM enrollmentCreateVM)
        {
            if (ModelState.IsValid)
            {
                await _enrollmentsService.Create(enrollmentCreateVM);
                return RedirectToAction(nameof(Index));
            }
            _enrollmentsService.UpdateLists(ViewData, enrollmentCreateVM.CourseSectionId, enrollmentCreateVM.StudentId);
            return View(enrollmentCreateVM);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = await _enrollmentsService.Get<EnrollmentEditVM>(id.Value);//_context.Enrollments.FindAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }

            _enrollmentsService.UpdateLists(ViewData, viewModel.CourseSectionId, viewModel.StudentId);
            return View(viewModel);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EnrollmentEditVM enrollmentEditVM)
        {
            if (id != enrollmentEditVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _enrollmentsService.Edit(enrollmentEditVM);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_enrollmentsService.EnrollmentExists(enrollmentEditVM.Id))
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
            _enrollmentsService.UpdateLists(ViewData, enrollmentEditVM.CourseSectionId, enrollmentEditVM.StudentId);
            return View(enrollmentEditVM);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewData = await _enrollmentsService.Get<EnrollmentDeleteVM>(id.Value);
            if (viewData == null)
            {
                return NotFound();
            }

            return View(viewData);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _enrollmentsService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
