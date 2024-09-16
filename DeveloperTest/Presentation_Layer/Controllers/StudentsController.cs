using Data_Access_Layer.Data;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public StudentsController(SchoolDbContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> SearchStudents(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Search term is empty.");
            }

            var students = await _context.Students
                .Include(s => s.Class)
                .Where(s => s.Name.Contains(name))
                .Select(s => new StudentDTO
                {
                    StudentId = s.StudentId,
                    Name = s.Name,
                    ClassRollNumber = s.ClassRollNumber,
                    ClassName = s.Class.ClassName,
                    Image = s.Image != null ? Convert.ToBase64String(s.Image) : null
                })
                .ToListAsync();

            return Ok(students);
        }



        // Add a student
        [HttpPost]
        public async Task<ActionResult<StudentDTO>> PostStudent([FromForm] CreateStudentDTO studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                Age = studentDto.Age,
                ClassRollNumber = studentDto.ClassRollNumber,
                ClassId = studentDto.ClassId,
                Image = studentDto.Image != null ? ConvertImageToBytes(studentDto.Image) : null
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            var studentToReturn = new StudentDTO
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Age = student.Age,
                ClassRollNumber = student.ClassRollNumber,
                ClassName = (await _context.Classes.FindAsync(student.ClassId)).ClassName
            };

            return CreatedAtAction(nameof(GetStudentsClassWise), new { id = student.StudentId }, studentToReturn);
        }

        // Get all students class-wise
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<ClassWithStudentsDTO>>> GetStudentsClassWise()
        {
            var students = await _context.Students
                .Include(s => s.Class)
                .ToListAsync();

            var classWiseStudents = students.GroupBy(s => s.Class.ClassName)
                .Select(g => new ClassWithStudentsDTO
                {
                    ClassName = g.Key,
                    Students = g.Select(s => new StudentDTO
                    {
                        StudentId = s.StudentId,
                        Name = s.Name,
                        ClassRollNumber = s.ClassRollNumber,
                        ClassName = s.Class.ClassName,
                        Image = s.Image != null ? Convert.ToBase64String(s.Image) : null  // Convert byte array to base64 string
                    }).ToList()
                }).ToList();

            return Ok(classWiseStudents);
        }

        private byte[] ConvertImageToBytes(IFormFile image)
        {
            using var memoryStream = new MemoryStream();
            image.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
