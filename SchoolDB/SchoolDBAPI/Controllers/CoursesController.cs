using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDBAPI.DTO;
using SchoolDBAPI.DTO.BasicDetailDTO;
using SchoolDBAPI.Library.DataAccess;
using SchoolDBAPI.Library.Models.SchoolBusiness;

namespace SchoolDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly SchoolDBContext context;

        public CoursesController(SchoolDBContext context)
        {
            this.context = context;
        }

        // GET: api/Courses
        [HttpGet]
        [HttpGet("search/title")]
        public async Task<ActionResult<IEnumerable<CourseReadDTO>>> GetCourses()
        {
            var courses = context.Courses
                .Include(c => c.Teacher)
                .ToList();

            var coursesData = new List<CourseReadDTO>();

            foreach (var course in courses)
            {
                CourseReadDTO courseData = new CourseReadDTO
                {
                    Id = course.Id,
                    Title = course.Title,
                    Teacher = new TeacherBasicDetailDTO { Id = course.Teacher.Id, FullName = course.Teacher.FullName },
                    Subject = course.Subject.ToString(),
                    CourseId = course.CourseId
                };

                courseData.Students = context.Enrollments
                .Where(e => e.CourseId == course.Id)
                .Select(e => new StudentBasicDetailDTO
                {
                    Id = e.Student.Id,
                    FirstName = e.Student.FirstName,
                    LastName = e.Student.LastName
                })
                .ToList();

                coursesData.Add(courseData);
            }

            return coursesData;
        }

        [HttpGet("search/title/{query}")]
        public async Task<ActionResult<IEnumerable<CourseReadDTO>>> SearchCourses(string query)
        {
            var courses = await context.Courses
                .Where(c => c.Title.Contains(query))
                .Include(c => c.Teacher)
                .ToListAsync();

            var coursesData = new List<CourseReadDTO>();

            foreach (var course in courses)
            {
                CourseReadDTO courseData = new CourseReadDTO
                {
                    Id = course.Id,
                    Title = course.Title,
                    Teacher = new TeacherBasicDetailDTO { Id = course.Teacher.Id, FullName = course.Teacher.FullName },
                    Subject = course.Subject.ToString(),
                    CourseId = course.CourseId
                };

                courseData.Students = context.Enrollments
                .Where(e => e.CourseId == course.Id)
                .Select(e => new StudentBasicDetailDTO
                {
                    Id = e.Student.Id,
                    FirstName = e.Student.FirstName,
                    LastName = e.Student.LastName
                })
                .ToList();

                coursesData.Add(courseData);
            }

            return coursesData;
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseReadDTO>> GetCourse(int id)
        {
            var course = context.Courses
                .Where(c => c.Id == id)
                .Include(c => c.Teacher)
                .FirstOrDefault();

            var courseData = new CourseReadDTO
            {
                Id = course.Id,
                Title = course.Title,
                Teacher = new TeacherBasicDetailDTO { Id = course.Teacher.Id, FullName = course.Teacher.FullName },
                Subject = course.Subject.ToString(),
                CourseId = course.CourseId
            };

            var matchingStudents = context.Enrollments
                .Where(e => e.CourseId == course.Id)
                .Select(e => new StudentBasicDetailDTO
                {
                    Id = e.Student.Id,
                    FirstName = e.Student.FirstName,
                    LastName = e.Student.LastName
                })
                .ToList();

            courseData.Students = matchingStudents;

            return courseData;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            context.Entry(course).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/Courses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(CoursePostDTO course)
        {
            var enrollments = new List<Enrollment>();
            var newCourse = new Course
            {
                Title = course.Title,
                CourseId = course.CourseId,
                Subject = course.Department,
                TeacherId = course.TeacherAssigned.Id
            };

            foreach (var student in course.EnrolledStudents)
            {
                enrollments.Add(new Enrollment
                {
                    StudentId = student.Id,
                    CourseId = newCourse.Id // id is currently not available
                });
            }

            context.Courses.Add(newCourse);
            await context.SaveChangesAsync();

            // TODO: fix this
            return CreatedAtAction("GetCourse", new { id = 0 }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Course>> DeleteCourse(int id)
        {
            var course = await context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            context.Courses.Remove(course);
            await context.SaveChangesAsync();

            return course;
        }

        [HttpGet("subjects/{subject}")]
        public async Task<List<CourseReadDTO>> GetCoursesBySubject(Subject subject)
        {

            var courses = context.Courses
                .Where(c => c.Subject == subject)
                .Include(c => c.Teacher)
                .ToList();

            var coursesData = new List<CourseReadDTO>();

            foreach (var course in courses)
            {
                CourseReadDTO courseData = new CourseReadDTO
                {
                    Id = course.Id,
                    Title = course.Title,
                    Teacher = new TeacherBasicDetailDTO { Id = course.Teacher.Id, FullName = course.Teacher.FullName },
                    Subject = course.Subject.ToString(),
                    CourseId = course.CourseId
                };

                courseData.Students = context.Enrollments
                .Where(e => e.CourseId == course.Id)
                .Select(e => new StudentBasicDetailDTO
                {
                    Id = e.Student.Id,
                    FirstName = e.Student.FirstName,
                    LastName = e.Student.LastName
                })
                .ToList();

                coursesData.Add(courseData);
            }

            return coursesData;
        }

        private bool CourseExists(int id)
        {
            return context.Courses.Any(e => e.Id == id);
        }
    }
}
