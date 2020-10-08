using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDBAPI.Library.DataAccess;
using SchoolDBAPI.Library.Models.People;
using SchoolDBAPI.DTO;

namespace SchoolDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SchoolDBContext context;

        public StudentsController(SchoolDBContext context)
        {
            this.context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentReadDTO>>> GetStudents()
        {
            var students = await context.Students.ToListAsync();

            var studentsData = new List<StudentReadDTO>();

            foreach (var student in students)
            {
                StudentReadDTO studentData = new StudentReadDTO
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Grade = student.Grade,
                    StudentId = student.StudentId
                };

                var matchingCourses = context.Enrollments
                    .Where(e => e.StudentId == student.Id)
                    .Select(e => e.Course.Title).ToList();

                studentData.CoursesEnrolledIn = matchingCourses;

                studentsData.Add(studentData);
            }

            return studentsData;
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentReadDTO>> GetStudent(int id)
        {
            var student = await context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            StudentReadDTO studentData = new StudentReadDTO
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Grade = student.Grade,
                StudentId = student.StudentId
            };

            var matchingCourses = context.Enrollments
                .Where(e => e.StudentId == student.Id)
                .Select(e => e.Course.Title).ToList();

            studentData.CoursesEnrolledIn = matchingCourses;

            return studentData;
        }

        [HttpGet("enroll/{id}")]
        public async Task<EnrollmentReadDTO> GetEnrollment(int id)
        {
            var enrollment = context.Enrollments
                .Where(e => e.EnrollmentId == id)
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefault();                

            var enrollmentData = new DTO.EnrollmentReadDTO
            {
                EnrollmentId = enrollment.EnrollmentId,
                CourseTitle = enrollment.Course.Title,
                StudentName = enrollment.Student.FullName
            };

            return enrollmentData;
        }

        [HttpGet("course/{id}")]
        public async Task<CourseReadDTO> GetCourse(int id)
        {
            var course = context.Courses.Find(id);
            //course.Teacher = _context.Teachers.Where(c => c.Id == course.TeacherId).FirstOrDefault();

            var courseData = new CourseReadDTO
            {
                Id = course.Id,
                Title = course.Title,
                Teacher = course.Teacher.FirstName + " " + course.Teacher.LastName
            };

            var matchingStudents = context.Enrollments
                .Where(e => e.CourseId == course.Id)
                .Select(e => e.Student.FirstName + " " + e.Student.LastName).ToList();

            courseData.Students = matchingStudents;

            return courseData;
        }

        // GET: api/Students/5
        [HttpGet("teachers/{id}")]
        public async Task<ActionResult<TeacherReadDTO>> GetTeacher(int id)
        {
            var teacher = await context.Teachers.FindAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            TeacherReadDTO teacherData = new TeacherReadDTO
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Salary = teacher.Salary,
                CoursesTaught = new List<string>()
            };

            var matchingCourses = context.Courses
                .Where(c => c.TeacherId == id)
                .Select(c => c.Title).ToList();

            teacherData.CoursesTaught = matchingCourses;

            return teacherData;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            context.Entry(student).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Students
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            context.Students.Add(student);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            context.Students.Remove(student);
            await context.SaveChangesAsync();

            return student;
        }

        private bool StudentExists(int id)
        {
            return context.Students.Any(e => e.Id == id);
        }
    }
}
