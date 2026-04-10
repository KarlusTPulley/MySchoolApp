using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySchoolApp.Web.Data;
using MySchoolApp.Web.Models.CourseSection;
using MySchoolApp.Web.Services;

namespace MySchoolApp.Web.Controllers
{
    public class CourseSectionsController : Controller
    {
        //private readonly ApplicationDbContext _context;
        //private readonly IMapper _mapper;
        private readonly ICourseSectionsService _courseSectionsService;

        public CourseSectionsController(ICourseSectionsService courseSectionsService)
        {
            //_context = context;
            //_mapper = mapper;
            _courseSectionsService = courseSectionsService;
        }

        // GET: CourseSections
        public async Task<IActionResult> Index()
        {
            var viewData = await _courseSectionsService.GetAllCoursesAsync();
            return View(viewData);
        }

        // GET: CourseSections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewData = await _courseSectionsService.Get<CourseSectionDetailsVM>(id.Value);
            if (viewData == null)
            {
                return NotFound();
            }

            return View(viewData);
        }

        // GET: CourseSections/Create
        public IActionResult Create()
        {
            _courseSectionsService.UpdateLists(ViewData);
            return View();
        }

        // POST: CourseSections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseSectionCreateVM courseSectionCreateVM)
        {
            if (ModelState.IsValid)
            {
                await _courseSectionsService.Create(courseSectionCreateVM);
                return RedirectToAction(nameof(Index));
            }
            _courseSectionsService.UpdateLists(ViewData);
            return View(courseSectionCreateVM);
        }

        // GET: CourseSections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseSectionEditVM = await _courseSectionsService.Get<CourseSectionEditVM>(id.Value);
            if (courseSectionEditVM == null)
            {
                return NotFound();
            }
            _courseSectionsService.UpdateLists(ViewData);
            return View(courseSectionEditVM);
        }

        // POST: CourseSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseSectionEditVM courseSectionEditVM)
        {
            if (id != courseSectionEditVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _courseSectionsService.Edit(courseSectionEditVM);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_courseSectionsService.CourseSectionExists(courseSectionEditVM.Id))
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
            _courseSectionsService.UpdateLists(ViewData);
            return View(courseSectionEditVM);
        }

        // GET: CourseSections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewData = await _courseSectionsService.Get<CourseSectionDeleteVM>(id.Value);
            if (viewData == null)
            {
                return NotFound();
            }

            return View(viewData);
        }

        // POST: CourseSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _courseSectionsService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
