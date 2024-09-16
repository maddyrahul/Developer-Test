using Data_Access_Layer.Data;
using Data_Access_Layer.Models;
using Data_Access_Layer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public SubjectsController(SchoolDbContext context)
        {
            _context = context;
        }

        // Add a subject
        [HttpPost]
        public async Task<ActionResult<SubjectDTO>> PostSubject([FromForm] CreateSubjectDTO subjectDto)
        {
            var subject = new Subject
            {
                Name = subjectDto.Name,
                Language = subjectDto.Language
            };

            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            // Create the many-to-many relationship with the teacher and class
            var teacherSubjectClass = new TeacherSubjectClass
            {
                TeacherId = subjectDto.TeacherId,
                SubjectId = subject.SubjectId,
                ClassId = subjectDto.ClassId
            };

            _context.TeacherSubjectClasses.Add(teacherSubjectClass);
            await _context.SaveChangesAsync();

            return Ok(new SubjectDTO
            {
                SubjectId = subject.SubjectId,
                Name = subject.Name,
                Language = subject.Language
            });
        }

       

        // Get all subjects with their respective teachers
        [HttpGet("with-teachers")]
        public async Task<ActionResult<IEnumerable<SubjectWithTeacherDTO>>> GetSubjectsWithTeachers()
        {
            var subjects = await _context.Subjects
                .Include(s => s.TeacherSubjectClasses)
                .ThenInclude(tsc => tsc.Teacher)
                .Include(s => s.TeacherSubjectClasses)
                .ThenInclude(tsc => tsc.Class)
                .ToListAsync();

            var subjectList = subjects.Select(s => new SubjectWithTeacherDTO
            {
                SubjectName = s.Name,
                Language = s.Language,
                ClassName = s.TeacherSubjectClasses.FirstOrDefault()?.Class.ClassName,
                TeacherName = s.TeacherSubjectClasses.FirstOrDefault()?.Teacher.Name
            }).ToList();

            return Ok(subjectList);
        }
    }
}


 


