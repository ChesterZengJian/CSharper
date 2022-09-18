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
using Microsoft.EntityFrameworkCore.Diagnostics;

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

            //var options = new DbContextOptionsBuilder<SchoolContext>()
            //    .UseInMemoryDatabase("School")
            //    .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            //    .Options;
            //m_schoolContext = new SchoolContext(options);

        }

        public async Task<ActionResult<string>> Index()
        {

            var data = await m_schoolContext.Departments.Select(d => d.Id.ToString()).FirstOrDefaultAsync();

            return View();

            //var students = await m_schoolContext.Students.ToListAsync();
            //var student = await m_schoolContext.Students
            //    //.Include(s => s.Enrollments)
            //    //.ThenInclude(e => e.Course)
            //    //.AsNoTracking()
            //    .FirstOrDefaultAsync(m => m.Id == 1);
            //Console.WriteLine($"Before change table, IsUseCoursePartition = {m_schoolContext.IsUseCoursePartition}, the table is '{m_schoolContext.Model.FindEntityType(typeof(Course)).GetTableName()}'");
            //await using (var schoolDbContext = new SchoolContext { IsUseCoursePartition = true })
            //{
            //    Console.WriteLine($"After new context, IsUseCoursePartition = {schoolDbContext.IsUseCoursePartition}, the table is '{schoolDbContext.Model.FindEntityType(typeof(Course)).GetTableName()}'");
            //}
            //var course = await m_schoolContext.Courses.FirstOrDefaultAsync();
            //var enrollment = await m_schoolContext.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentId == 1);
            //return course.Title;
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
