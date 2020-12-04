using Caliburn.Micro;
using SchoolDBUI.Library.API;
using SchoolDBUI.Library.Models;
using SchoolDBUI.Library.Models.SubmitDTOs;
using SchoolDBUI.Library.Models.SchoolBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SchoolDBUI.EventCommands;

namespace SchoolDBUI.ViewModels.CourseManagement
{
    public class CourseManagementViewModel : Screen, IHandle<CourseCommand>
    {
        private readonly ICourseEndpoint courseEndpoint;
        private readonly ITeacherEndpoint teacherEndpoint;
        private readonly IStudentEndpoint studentEndpoint;
        private readonly IEventAggregator eventAggregator;

        private bool IsEditMode = false;

        public CourseManagementViewModel(
            ICourseEndpoint courseEndpoint,
            ITeacherEndpoint teacherEndpoint,
            IStudentEndpoint studentEndpoint,
            IEventAggregator events)
        {
            this.courseEndpoint = courseEndpoint;
            this.teacherEndpoint = teacherEndpoint;
            this.studentEndpoint = studentEndpoint;
            eventAggregator = events;

            LoadCourses();
        }

        private string modeMsg;

        public string ModeMsg // upon submit, clear msg
        {
            get { return modeMsg; }
            set
            {
                modeMsg = value;
                NotifyOfPropertyChange(() => ModeMsg);
            }
        }


        public void Handle(CourseCommand cmd)
        {
            if (cmd == CourseCommand.NewCourse)
            {
                ModeMsg = "Add New Course";
                IsEditMode = false;
            }

            if (cmd == CourseCommand.SaveCourse)
            {
                CreateCourse();
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
                NotifyOfPropertyChange(() => CourseNotSelected);
            }
        }

        private void SetUpEditMode()
        {
            if (SelectedCourse != null)
            {
                EnableEditMode();
                CourseTitleTextbox = SelectedCourse.Title;
                CourseIdTextbox = SelectedCourse.CourseId;
                SelectedTeacher = null; // setting this to null helps trigger the combo box to change
                SelectedTeacher = SelectedCourse.Teacher;
                EnrolledStudents = null;
                EnrolledStudents = new BindingList<Student>(SelectedCourse.Students);
            }
        }

        private void EnableEditMode()
        {
            ModeMsg = "Edit Course";
            IsEditMode = true;
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
                if (selectedSubjectFilter != null)
                {
                    SetTeacherFilter();
                }
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

        public bool CourseNotSelected
        {
            get
            {
                return SelectedCourse != null;
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

        public IEnumerable<CourseLevel> CourseLevels
        {
            get
            {
                return Enum.GetValues(typeof(CourseLevel))
                    .Cast<CourseLevel>();
            }
        }

        private string selectedCourseLevel;
        public string SelectedCourseLevel
        {
            get { return selectedCourseLevel; }
            set
            {
                selectedCourseLevel = value;
                NotifyOfPropertyChange(() => SelectedCourseLevel);
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
            var courseList = await courseEndpoint.GetAll();
            Courses = null;
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
            var filteredCourses = await courseEndpoint.SearchCoursesByTitle(CourseNameTextbox.Trim());

            Courses = new BindingList<Course>(filteredCourses);
        }

        #endregion

        #region Enroll Students

        private async Task LoadStudents()
        {
            var studentList = await studentEndpoint.GetAll();

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

        private Student selectedEnrolledStudent;

        public Student SelectedEnrolledStudent
        {
            get { return selectedEnrolledStudent; }
            set
            {
                selectedEnrolledStudent = value;
                NotifyOfPropertyChange(() => SelectedEnrolledStudent);
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
            if (SelectedStudent == null || SelectedCourse == null)
            {
                return;
            }

            if (!IsStudentAlreadyEnrolled())
            {
                EnrolledStudents.Add(SelectedStudent);
            }
        }

        public void UnenrollStudent()
        {
            if (SelectedCourse != null && SelectedEnrolledStudent != null)
            {
                EnrolledStudents.Remove(SelectedEnrolledStudent);
                NotifyOfPropertyChange(() => EnrolledStudents);
            }

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

        public async Task CreateCourse()
        {
            Enum.TryParse(SelectedSubjectFilter, out Subject subject);
            Enum.TryParse(SelectedCourseLevel, out CourseLevel courseLevel);

            var course = new CourseSubmitDTO
            {
                Title = CourseTitleTextbox,
                CourseId = CourseIdTextbox,
                Department = subject,
                TeacherAssigned = SelectedTeacher,
                // use a different student class to avoid unnecessary references and lighten the load?
                CourseLevel = courseLevel,
                EnrolledStudents = EnrolledStudents.ToList()
            };

            if (IsEditMode)
            {
                await courseEndpoint.UpdateCourse(SelectedCourse.Id, course);
            }
            else
            {
                await courseEndpoint.SubmitCourse(course);
            }

            LoadCourses();
        }

        public async Task DeleteCourse()
        {
            // TODO: add warning
            await courseEndpoint.DeleteCourse(selectedCourse.Id);

            LoadCourses();
        }

        protected override void OnActivate()
        {
            eventAggregator.Subscribe(this);
            base.OnActivate();
        }

        protected override void OnDeactivate(bool close)
        {
            eventAggregator.Unsubscribe(this);
            base.OnDeactivate(close);
        }
    }
}
