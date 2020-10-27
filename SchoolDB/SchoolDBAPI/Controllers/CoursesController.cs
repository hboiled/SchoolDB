using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await context.Courses.ToListAsync();
        }

        [HttpGet("search/title/{query}")]
        public async Task<ActionResult<IEnumerable<Course>>> SearchCourses(string query)
        {
            var courses = await context.Courses
                .Where(c => c.Title.Contains(query))
                .ToListAsync();

            return courses;
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
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
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            context.Courses.Add(course);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
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

        private bool CourseExists(int id)
        {
            return context.Courses.Any(e => e.Id == id);
        }
    }
}
