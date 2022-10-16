using Microsoft.EntityFrameworkCore;
using TEST_QLSV.Data;
using TEST_QLSV.Models;

namespace TEST_QLSV.Services
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _context;
        public StudentService(DataContext context)
        {
            _context = context;
        }

        public void CreateStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var existEntity = GetStudentById(id);
            if (existEntity == null) return;
            _context.Students.Remove(existEntity);
            _context.SaveChanges();
            
        }

        public List<Class> GetClasses()
        {
            return _context.Classes.ToList();
        }

        public Student? GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(p => p.Id == id);
        }

        public List<Student> GetStudents()
        {
            return _context.Students
            .Include(x => x.Class)
            .ToList();
        }
        public List<Student> FilterStudents(string find)
        {
            return _context.Students
            .Where(s=>s.Name.Contains(find)).ToList();
        }

        public void UpdateStudent(Student student)
        {
            var existEntity = GetStudentById(student.Id);
            if (existEntity == null) return;
            existEntity.Name = student.Name;
            existEntity.Gender = student.Gender;
            existEntity.DOB = student.DOB;
            existEntity.Address = student.Address;
            existEntity.ClassId = student.ClassId;
            _context.Update(existEntity);
            _context.SaveChanges();
        }
    }
}
