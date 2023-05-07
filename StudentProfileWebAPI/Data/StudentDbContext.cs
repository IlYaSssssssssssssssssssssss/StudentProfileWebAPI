using Microsoft.EntityFrameworkCore;
using StudentProfileWebAPI.Model;

namespace StudentProfileWebAPI.Data
{
    public class StudentDbContext :DbContext
    {
        public StudentDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("StudentDb");
        }

        public DbSet<Student > Students { get; set; }
    }
}
