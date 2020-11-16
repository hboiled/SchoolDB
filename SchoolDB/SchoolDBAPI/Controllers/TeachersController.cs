using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDBAPI.DTO;
using SchoolDBAPI.Library.DataAccess;
using SchoolDBAPI.Library.Models.People;
using SchoolDBAPI.Library.Models.SchoolBusiness;

namespace SchoolDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly SchoolDBContext context;

        public TeachersController(SchoolDBContext context)
        {
            this.context = context;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            return await context.Teachers.ToListAsync();
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await context.Teachers.FindAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }

        // GET: api/Teachers/maths
        [HttpGet("subjects/{subject}")]
        public async Task<List<Teacher>> GetTeachersBySubject(Subject subject)
        {
            var subjectTeachers = await context.SubjectTeachers
                .Where(s => s.Subject == subject)
                .Select(s => s.TeacherId)
                .ToListAsync();

            var teachers = await context.Teachers
                .Where(t => subjectTeachers.Contains(t.Id))
                .ToListAsync();

            return teachers;
            
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            context.Entry(teacher).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Teachers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher(TeacherPostDTO teacher)
        {
            var teacherData = new Teacher
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Gender = teacher.Gender,
                Salary = teacher.Salary,
            };

            context.Teachers.Add(teacherData);
            await context.SaveChangesAsync();

            // subjects teachable
            var subjectsTeacherCanTeach = teacher.SubjectTeachers
                .Select(st => new SubjectsTeachersCanTeach
                {
                    TeacherId = teacherData.Id,
                    Subject = st.Subject,
                    CourseLevel = st.CourseLevel
                })
                .ToList();

            context.SubjectTeachers.AddRange(subjectsTeacherCanTeach);

            // courses taught
            // override previous teacher or not? display warning?
            var teacherCoursesToTeach = teacher.CoursesTaught
                .Select(c => c.Id)
                .ToList();

            var courses = context.Courses
                .Where(c => teacherCoursesToTeach.Contains(c.Id))
                .ToList();

            foreach (var course in courses)
            {
                course.TeacherId = teacherData.Id;
            }

            await context.SaveChangesAsync();

            return CreatedAtAction("GetTeacher", new { id = teacherData.Id }, teacher);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher>> DeleteTeacher(int id)
        {
            var teacher = await context.Teachers.FindAsync(id);
            
            if (teacher == null)
            {
                return NotFound();
            }

            context.Teachers.Remove(teacher);
            await context.SaveChangesAsync();

            return teacher;
        }

        private bool TeacherExists(int id)
        {
            return context.Teachers.Any(e => e.Id == id);
        }
    }
}
