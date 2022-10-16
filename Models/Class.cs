namespace TEST_QLSV.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}
