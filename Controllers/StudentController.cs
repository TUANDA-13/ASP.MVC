using Microsoft.AspNetCore.Mvc;
using TEST_QLSV.Models;
using TEST_QLSV.Services;

namespace TEST_QLSV.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }

        public IActionResult Index(string searchName, int ClassId)
        {
            @ViewData["searchName"] = searchName;
            @ViewData["ClassId"] = ClassId;
            var classes = _service.GetClasses();
            ViewBag.Class = classes;
            var students = _service.GetStudents();
            Console.WriteLine("Search",searchName);
            Console.WriteLine("Class", ClassId);
            if (searchName==""){
                students = _service.FilterStudents(searchName);
            }
            else{
                
            }
            
            
            return View(students);
        }

        public IActionResult Create()
        {
            var classes = _service.GetClasses();
            return View(classes);
        }

        public IActionResult Save(Student student)
        {
            if (student.Id == 0)
            {
                _service.CreateStudent(student);
            }
            else
            {
                _service.UpdateStudent(student);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var student = _service.GetStudentById(id);
            if (student == null)
            {
                return RedirectToAction("Create");
            }
            var classes = _service.GetClasses();
            ViewBag.Student = student;
            return View(classes);
        }

        public IActionResult Delete(int id)
        {
            _service.DeleteStudent(id);
            return RedirectToAction("index");
        }
    }
}
