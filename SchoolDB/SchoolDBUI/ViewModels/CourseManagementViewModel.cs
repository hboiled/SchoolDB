using Caliburn.Micro;
using SchoolDBUI.Library.API;
using SchoolDBUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolDBUI.ViewModels
{
    public class CourseManagementViewModel : Screen, IHandle<string>
    {
        private readonly ICourseEndpoint courseEndpoint;
        private readonly ITeacherEndpoint teacherEndpoint;
        private readonly IStudentEndpoint studentEndpoint;
        private readonly IEventAggregator events;

        public CourseManagementViewModel(
            ICourseEndpoint courseEndpoint,
            ITeacherEndpoint teacherEndpoint,
            IStudentEndpoint studentEndpoint,
            IEventAggregator events)
        {
            this.courseEndpoint = courseEndpoint;
            this.teacherEndpoint = teacherEndpoint;
            this.studentEndpoint = studentEndpoint;
            this.events = events;
            events.Subscribe(this);
            LoadCourses();
        }

        private string addModeMsg;

        public string AddModeMsg // upon submit, clear msg
        {
            get { return addModeMsg; }
            set 
            { 
                addModeMsg = value;
                NotifyOfPropertyChange(() => AddModeMsg);
            }
        }


        public void Handle(string message)
        {
            if (message.Equals("New"))
            {
                AddModeMsg = "Add New Course";
            }
        }

        private Course selectedCourse;

        public Course SelectedCourse
        {
            get { return selectedCourse; }
            set
            {
                selectedCourse = value;
                SetUpEditMode();
                NotifyOfPropertyChange(() => SelectedCourse);                
            }
        }

        private void SetUpEditMode()
        {
            AddModeMsg = "Edit Course";
            CourseTitleTextbox = selectedCourse.Title;
            CourseIdTextbox = selectedCourse.CourseId;
            SelectedTeacher = null; // setting this to null helps trigger the combo box to change
            SelectedTeacher = selectedCourse.Teacher;
            EnrolledStudents = null;
            EnrolledStudents = new BindingList<Student>(selectedCourse.Students);
        }

        private string courseTitleTextbox;

        public string CourseTitleTextbox
        {
            get { return courseTitleTextbox; }
            set 
            {
                courseTitleTextbox = value;
                NotifyOfPropertyChange(() => CourseTitleTextbox);
            }
        }

        private string courseIdTextbox;

        public string CourseIdTextbox
        {
            get { return courseIdTextbox; }
            set 
            {
                courseIdTextbox = value;
                NotifyOfPropertyChange(() => CourseIdTextbox);
            }
        }


        #region Teacher Assignment

        private Teacher selectedTeacher;
        public Teacher SelectedTeacher 
        {
            get { return selectedTeacher; }
            set
            {
                selectedTeacher = value;
                NotifyOfPropertyChange(() => SelectedTeacher);                
            }
        }

        private string selectedSubjectFilter;
        public string SelectedSubjectFilter
        {
            get { return selectedSubjectFilter; }
            set
            {
                selectedSubjectFilter = value;
                SetTeacherFilter();
                NotifyOfPropertyChange(() => SelectedSubjectFilter);
            }
        }

        private async Task SetTeacherFilter()
        {
            // TODO: refactor logic to be more readable 
            if (Enum.TryParse(SelectedSubjectFilter, out Subject subject))
            {
                try
                {
                    var teachers = await teacherEndpoint.GetTeachersBySubject(subject);                    

                    FilterNotSelected = teachers.Count != 0;
                    FilteredTeachers = new BindingList<Teacher>(teachers);
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                }
                
                
            }
            else
            {
                ErrorMessage = "Valid subject was not chosen";
            }

        }

        private bool filterNotSelected = false;
        public bool FilterNotSelected
        {
            get
            {
                return filterNotSelected;
            }
            set
            {
                filterNotSelected = value;
                NotifyOfPropertyChange(() => FilterNotSelected);
            }
        }

        public IEnumerable<Subject> Subjects
        {
            get
            {
                return Enum.GetValues(typeof(Subject))
                    .Cast<Subject>();
            }
        }

        public BindingList<Teacher> filteredTeachers = new BindingList<Teacher>();

        public BindingList<Teacher> FilteredTeachers
        {
            get { return filteredTeachers; }
            set
            {
                filteredTeachers = value;
                NotifyOfPropertyChange(() => FilteredTeachers);
            }
        }
        #endregion

        #region Display error
        public bool IsErrorVisible
        {
            get
            {
                bool output = false;

                if (ErrorMessage?.Length > 0)
                {
                    output = true;
                }

                return output;
            }

        }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
                NotifyOfPropertyChange(() => IsErrorVisible);
            }
        }
        #endregion

        #region Courses list

        async Task LoadCourses()
        {
            var courseList = await this.courseEndpoint.GetAll();

            Courses = new BindingList<Course>(courseList);
        }

        private BindingList<Course> courses;

        public BindingList<Course> Courses
        {
            get { return courses; }
            set
            {
                courses = value;
                NotifyOfPropertyChange(() => Courses);
            }
        }

        private string courseNameTextbox;

        public string CourseNameTextbox
        {
            get { return courseNameTextbox; }
            set
            {
                courseNameTextbox = value;
                SearchCourses();
            }
        }

        private async Task SearchCourses()
        {
            var filteredCourses = await courseEndpoint.SearchCoursesByTitle(CourseNameTextbox);

            Courses = new BindingList<Course>(filteredCourses);
        }

        #endregion

        #region Enroll Students

        private async Task LoadStudents()
        {
            var studentList = await this.studentEndpoint.GetAll();

            Students = new BindingList<Student>(studentList);
        }

        private BindingList<Student> students;

        public BindingList<Student> Students
        {
            get { return students; }
            set
            {
                students = value;
                NotifyOfPropertyChange(() => Students);
            }
        }

        private Student selectedStudent;

        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                NotifyOfPropertyChange(() => SelectedStudent);
            }
        }

        private string studentNameTextBox;

        public string StudentNameTextbox
        {
            get { return studentNameTextBox; }
            set
            {
                studentNameTextBox = value;
                SearchStudents();
            }
        }

        private async Task SearchStudents()
        {
            var filteredStudents = await studentEndpoint.SearchStudent(StudentNameTextbox);

            Students = new BindingList<Student>(filteredStudents);
        }

        private BindingList<Student> enrolledStudents = new BindingList<Student>();

        public BindingList<Student> EnrolledStudents
        {
            get { return enrolledStudents; }
            set 
            {
                enrolledStudents = value;
                NotifyOfPropertyChange(() => EnrolledStudents);
            }
        }

        public void EnrollStudent()
        {
            if (!IsStudentAlreadyEnrolled())
            {
                EnrolledStudents.Add(SelectedStudent);
            }
        }

        public void UnenrollStudent()
        {
            EnrolledStudents.Remove(SelectedStudent);
        }

        public bool IsStudentAlreadyEnrolled()
        {
            bool output = false;

            if (EnrolledStudents.Contains(SelectedStudent))
            {
                output = true;
            }

            return output;
        }

        #endregion

        public void CreateCourse()
        {
            Enum.TryParse(SelectedSubjectFilter, out Subject subject);

            var course = new CourseSubmitDTO
            {
                Title = CourseTitleTextbox,
                CourseId = CourseIdTextbox,
                Department = subject,
                TeacherAssigned = SelectedTeacher,
                // use a different student class to avoid unnecessary references?
                EnrolledStudents = EnrolledStudents.ToList() 
            };
            var x = 1;
        }

        public void DeleteCourse()
        {

        }
    }
}
