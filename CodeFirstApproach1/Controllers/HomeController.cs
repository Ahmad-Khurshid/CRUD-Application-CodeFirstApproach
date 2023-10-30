using CodeFirstApproach1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodeFirstApproach1.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext Student;
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController(StudentDbContext Student)
        {
            this.Student = Student;
        }
        public IActionResult Index()
        {
            var std = Student.Students.ToList();
            return View(std);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentModel std)
        {
            if (ModelState.IsValid)
            {
                Student.Students.Add(std); 
                Student.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }
        public IActionResult Details(int id)
        {
            var stddetails = Student.Students.FirstOrDefault(x => x.Id == id);
            return View(stddetails);
        }
        public IActionResult Edit(int id)
        {
            var stddetails = Student.Students.Find(id);
            return View(stddetails);
        }
        [HttpPost]
        public IActionResult Edit(int id,StudentModel std)
        {
            if (ModelState.IsValid)
            {
                Student.Students.Update(std);
                Student.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            return View(std);
        }
        public IActionResult Delete(int id)
        {
            var stddel = Student.Students.FirstOrDefault(x => x.Id == id);
            return View(stddel);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var stddel = Student.Students.FirstOrDefault(x => x.Id == id);
            Student.Students.Remove(stddel);
            Student.SaveChanges();

            return RedirectToAction("Index", "Home");
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