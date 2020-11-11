using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDBAPI.Library.DataAccess;
using SchoolDBAPI.DTO;
using SchoolDBAPI.Library.Models;
using SchoolDBAPI.Library.Models.SchoolBusiness;
using SchoolDBAPI.Library.Models.People;
using SchoolDBAPI.DTO.BasicDetailDTO;

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
        [HttpGet("search/{query}")]
        public async Task<ActionResult<IEnumerable<StudentReadDTO>>> SearchStudents(string query)
        {            
            var students = await context.Students
                .Where(s => (s.FirstName + " " + s.LastName).Contains(query))
                .ToListAsync();

            var studentsData = new List<StudentReadDTO>();

            foreach (var student in students)
            {
                StudentReadDTO studentData = MapStudentToDTO(student);

                studentsData.Add(studentData);
            }

            return studentsData;
        }

        // GET: api/Students        
        [HttpGet]
        [HttpGet("search/")]
        public async Task<ActionResult<IEnumerable<StudentReadDTO>>> GetStudents()
        {
            var students = await context.Students.ToListAsync();

            var studentsData = new List<StudentReadDTO>();

            foreach (var student in students)
            {
                StudentReadDTO studentData = MapStudentToDTO(student);

                studentsData.Add(studentData);
            }

            return studentsData;
        }

        private StudentReadDTO MapStudentToDTO(Student student)
        {
            StudentReadDTO studentData = new StudentReadDTO
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Grade = student.Grade,
                StudentId = student.StudentId,
                Gender = student.Gender,
                BirthDate = student.BirthDate,
                PhotoImgPath = student.PhotoImgPath
            };

            var matchingCourses = context.Enrollments
            .Where(e => e.StudentId == student.Id)
            .Select(e => new CourseBasicDetailDTO
            {
                CourseId = e.Course.CourseId,
                Title = e.Course.Title,
                StudentGrade = "N/A",
                Subject = e.Course.Subject.ToString(),
                Teacher = new TeacherBasicDetailDTO
                {
                    Id = e.Course.Teacher.Id,
                    FirstName = e.Course.Teacher.FirstName,
                    LastName = e.Course.Teacher.LastName,
                    Gender = e.Course.Teacher.Gender,
                    Salary = e.Course.Teacher.Salary
                }
            })
            .ToList();

            var matchingEmails = context.StudentEmails
                .Where(e => e.StudentId == student.Id)
                .Select(e => new EmailBasicDetailDTO
                {
                    EmailAddress = e.EmailAddress,
                    IsSchoolEmail = e.IsSchoolEmail,
                    Owner = e.Owner
                })
                .ToList();

            //var enumType = typeof(PhoneNumberOwner); // alternative way of getting name 
            var matchingPhoneNums = context.StudentPhoneNumbers
                .Where(p => p.StudentId == student.Id)
                .Select(p => new PhoneNumBasicDetailDTO
                {
                    Number = p.Number,
                    Owner = p.Owner,
                    IsEmergency = p.IsEmergency,
                    IsMobile = p.IsMobile
                })
                .ToList();

            var matchingAddresses = context.StudentAddresses
                .Where(a => a.StudentId == student.Id)
                .Select(a => new AddressBasicDetailDTO
                {
                    StreetAddress = a.StreetAddress,
                    Suburb = a.Suburb,
                    City = a.City,
                    State = a.State,
                    Postcode = a.Postcode,
                    IsPrimary = a.IsPrimary
                })
                .ToList();

            studentData.CoursesEnrolledIn = matchingCourses;
            studentData.Emails = matchingEmails;
            studentData.PhoneNumbers = matchingPhoneNums;
            studentData.Addresses = matchingAddresses;
            return studentData;
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

            StudentReadDTO studentData = MapStudentToDTO(student);

            return studentData;
        }

        // Where to place this? Undecided
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
        public async Task<ActionResult<StudentPostDTO>> PostStudent(StudentPostDTO studentData)
        //public async Task<ActionResult<Student>> PostStudent(Student studentData)
        {
            // NOTE: TRANSACTION HERE - REDO TO WORK SAFELY
            var student = new Student
            {
                FirstName = studentData.FirstName,
                LastName = studentData.LastName,
                Grade = studentData.Grade,
                StudentId = 436894, // change every so often     
                Gender = studentData.Gender,
                PhotoImgPath = studentData.PhotoImgPath,
                BirthDate = studentData.BirthDate, // date only? is it saving date and time?                
            };

            context.Students.Add(student);
            await context.SaveChangesAsync();

            var addresses = studentData.Addresses;
            var emails = studentData.Emails;
            var phoneNums = studentData.PhoneNums;
            var courses = studentData.CourseEnrollments;

            var enrollments = new List<Enrollment>();

            // HACK -- NEEDS TO BE CHANGED AFTER LEARNING MORE ABOUT TRANSACTIONS
            var studentsId = context.Students.
                Where(s => s.StudentId == student.StudentId).
                FirstOrDefault().Id;

            foreach (var course in courses)
            {
                enrollments.Add(new Enrollment
                {
                    StudentId = studentsId,
                    CourseId = course.Id
                });
            }

            foreach (var email in emails)
            {
                email.StudentId = studentsId;
            }

            foreach (var number in phoneNums)
            {
                number.StudentId = studentsId;
            }

            foreach (var address in addresses)
            {
                address.StudentId = studentsId;
            }

            context.StudentAddresses.AddRange(addresses);
            context.StudentEmails.AddRange(emails);
            context.StudentPhoneNumbers.AddRange(phoneNums);
            context.Enrollments.AddRange(enrollments);            
            await context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = 1 }, student); // fix required
            //return CreatedAtAction("GetStudent", new { id = studentsId }, student);
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
