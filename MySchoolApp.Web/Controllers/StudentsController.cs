using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySchoolApp.Web.Data;
using MySchoolApp.Web.Models.Students;
using MySchoolApp.Web.Services;

namespace MySchoolApp.Web.Controllers
{
    public class StudentsController : Controller
    {
        //private readonly ApplicationDbContext _context;
        //private readonly IMapper _mapper;
        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
            //_context = context;
            //_mapper = mapper;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var viewData = await _studentsService.GetAllStudentsAsync();
            return View(viewData);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = await _studentsService.Get<StudentDetailsVM>(id.Value);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentCreateVM studentCreateVM)
        {
            if (ModelState.IsValid)
            {
                await _studentsService.Create(studentCreateVM);
                return RedirectToAction(nameof(Index));
            }
            return View(studentCreateVM);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentEditVM = await _studentsService.Get<StudentEditVM>(id.Value);
            if (studentEditVM == null)
            {
                return NotFound();
            }

            return View(studentEditVM);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentEditVM studentEditVM)
        {
            if (id != studentEditVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _studentsService.Edit(studentEditVM);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_studentsService.StudentExists(studentEditVM.Id))
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


            return View(studentEditVM);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentDeleteVM = await _studentsService.Get<StudentDeleteVM>(id.Value);
            if (studentDeleteVM == null)
            {
                return NotFound();
            }
            var enrollmentExist = await _studentsService.CheckIfEnrollmentExist(studentDeleteVM.Id);
            if (enrollmentExist)
            {
                //todo give message you can't delete or grey out
                return RedirectToAction(nameof(Index));
            }

           
            return View(studentDeleteVM);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _studentsService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
