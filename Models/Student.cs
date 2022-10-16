using System.ComponentModel.DataAnnotations;

namespace TEST_QLSV.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public virtual Class Class { get; set; }
        public int ClassId { get; set; }
    }
}