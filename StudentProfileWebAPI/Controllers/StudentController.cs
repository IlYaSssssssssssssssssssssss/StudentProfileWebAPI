using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentProfileWebAPI.Data;
using StudentProfileWebAPI.DTO;
using StudentProfileWebAPI.Model;

namespace StudentProfileWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var getAllStudent = await _studentDbContext.Students.ToListAsync();
            return Ok(getAllStudent);
        }
         

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var studentId = await _studentDbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
            return Ok(studentId);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostAsync(StudentDto student)
        {
            Student newStudent  = new Student();
            newStudent.Id = Guid.NewGuid();
            newStudent.FirstName = student.FirstName;
            newStudent.LastName = student.LastName;
            newStudent.Grade = student.Grade;
            newStudent.Class = student.Class;
            newStudent.Subject = student.Subject;
            await _studentDbContext.Students.AddAsync(newStudent);
            await _studentDbContext.SaveChangesAsync();
            return Ok(newStudent);
        }

    }
}
