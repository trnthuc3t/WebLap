using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    [Route("Admin/Student")] // Base route for the controller
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();

        public StudentController()
        {
            // Initialize the list of students with 4 sample data entries
            listStudents = new List<Student>()
            {
               new Student() { Id = 101, Name = "Hải Nam", Branch = Branch.IT,
                   Gender = Gender.Male, IsRegular=true,
                   Address = "A1-2018", Email = "nam@g.com" },
               new Student() { Id = 102, Name = "Minh Tú", Branch = Branch.BE,
                   Gender = Gender.Female, IsRegular=true,
                   Address = "A1-2019", Email = "tu@g.com" },
               new Student() { Id = 103, Name = "Hoàng Phong", Branch = Branch.CE,
                   Gender = Gender.Male, IsRegular=false,
                   Address = "A1-2020", Email = "phong@g.com" },
               new Student() { Id = 104, Name = "Xuân Mai", Branch = Branch.EE,
                   Gender = Gender.Female, IsRegular = false,
                   Address = "A1-2021", Email = "mai@g.com" }
            };
        }

        [Route("List")] // Route for Index action
        public IActionResult Index()
        {
            // Return the Index.cshtml view with the list of students as the model
            return View(listStudents);
        }

        [HttpGet]
        [Route("Add")] // Route for Create GET action
        public IActionResult Create()
        {
            // Retrieve the list of Gender values to display radio buttons on the form
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            // Retrieve the list of Branch values to display as select-options on the form
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };

            return View();
        }

        [HttpPost]
        [Route("Add")] // Route for Create POST action
        public IActionResult Create(Student s)
        {
            s.Id = listStudents.Last<Student>().Id + 1;
            listStudents.Add(s);
            return View("Index", listStudents);
        }


       

    }
}