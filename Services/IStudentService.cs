using TEST_QLSV.Models;

namespace TEST_QLSV.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student? GetStudentById(int id);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        List<Class> GetClasses();
        List<Student> FilterStudents(string find);
    }
}
