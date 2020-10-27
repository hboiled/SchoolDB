using Caliburn.Micro;
using SchoolDBUI.Library.API;
using SchoolDBUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBUI.ViewModels
{
    public class CourseManagementViewModel : Screen
    {
        private readonly ICourseEndpoint courseEndpoint;
        private readonly ITeacherEndpoint teacherEndpoint;

        public CourseManagementViewModel(
            ICourseEndpoint courseEndpoint,
            ITeacherEndpoint teacherEndpoint)
        {
            this.courseEndpoint = courseEndpoint;
            this.teacherEndpoint = teacherEndpoint;
            LoadCourses();
        }

        #region Teacher Assignment

        public Teacher SelectedTeacher { get; set; }

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
    }
}
