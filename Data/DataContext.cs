using Microsoft.EntityFrameworkCore;
using TEST_QLSV.Models;

namespace TEST_QLSV.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }

    }
}
