using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproach1.Models
{
    public class StudentDbContext :DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<StudentModel> Students { get; set; }
    }
}
