using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EFCoreDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SchoolContext m_schoolContext;

        public HomeController(ILogger<HomeController> logger, SchoolContext schoolContext)
        {
            _logger = logger;
            m_schoolContext = schoolContext;
        }

        public async Task<ActionResult> Index()
        {
            var students = await m_schoolContext.Students.ToListAsync();
            var student = await m_schoolContext.Students
                //.Include(s => s.Enrollments)
                //.ThenInclude(e => e.Course)
                //.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == 1);
            var course = await m_schoolContext.Courses.FirstOrDefaultAsync(c => c.CourseId == 1050);
            var enrollment = await m_schoolContext.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentId == 1);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
