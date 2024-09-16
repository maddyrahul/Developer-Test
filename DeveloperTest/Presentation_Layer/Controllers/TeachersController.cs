using Data_Access_Layer.Data;
using Data_Access_Layer.Models;
using Data_Access_Layer.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public TeachersController(SchoolDbContext context)
        {
            _context = context;
        }

        // Add a teacher
        [HttpPost]
        public async Task<ActionResult<TeacherDTO>> PostTeacher([FromForm] CreateTeacherDTO teacherDto)
        {
            var teacher = new Teacher
            {
                Name = teacherDto.Name,
                Age = teacherDto.Age,
                Sex = teacherDto.Sex,
                Image = teacherDto.Image != null ? ConvertImageToBytes(teacherDto.Image) : null
            };

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            var teacherToReturn = new TeacherDTO
            {
                TeacherId = teacher.TeacherId,
                Name = teacher.Name,
                Age = teacher.Age,
                Sex = teacher.Sex
            };

            return CreatedAtAction(nameof(GetTeachers), new { id = teacher.TeacherId }, teacherToReturn);
        }

        // Get all teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherDTO>>> GetTeachers()
        {
            var teachers = await _context.Teachers
                .ToListAsync();

            return Ok(teachers.Select(t => new TeacherDTO
            {
                TeacherId = t.TeacherId,
                Name = t.Name,
                Age = t.Age,
                Sex = t.Sex
            }));
        }

        private byte[] ConvertImageToBytes(IFormFile image)
        {
            using var memoryStream = new MemoryStream();
            image.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
