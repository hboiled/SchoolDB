using Caliburn.Micro;
using SchoolDBUI.Library.API;
using SchoolDBUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBUI.ViewModels.StudentManagement
{
    public class StudentCourseEnrollViewModel : Screen
    {
        private readonly ICourseEndpoint courseEndpoint;

        public StudentCourseEnrollViewModel(ICourseEndpoint courseEndpoint)
        {
            this.courseEndpoint = courseEndpoint;
        }

        #region Course and subject filter

        private string selectedSubjectFilter;
        public string SelectedSubjectFilter
        {
            get { return selectedSubjectFilter; }
            set
            {
                selectedSubjectFilter = value;
                SetCourseFilter();
                NotifyOfPropertyChange(() => SelectedSubjectFilter);
            }
        }

        private async Task SetCourseFilter()
        {
            // TODO: refactor logic to be more readable 
            if (Enum.TryParse(SelectedSubjectFilter, out Subject subject))
            {
                var courses = await courseEndpoint.GetCoursesBySubject(subject);
                FilterNotSelected = courses.Count != 0;
                FilteredCourses = new BindingList<Course>(courses);
            }
            else
            {
                // handler error
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

        public BindingList<Course> filteredCourses = new BindingList<Course>();

        public BindingList<Course> FilteredCourses
        {
            get { return filteredCourses; }
            set
            {
                filteredCourses = value;
                NotifyOfPropertyChange(() => FilteredCourses);
            }
        }

        private BindingList<Course> coursesEnrolledIn = new BindingList<Course>();

        public BindingList<Course> CoursesEnrolledIn
        {
            get { return coursesEnrolledIn; }
            set { coursesEnrolledIn = value; }
        }

        private Course selectedCourse;

        public Course SelectedCourse
        {
            get { return selectedCourse; }
            set { selectedCourse = value; }
        }

        private Course enrolledCourseSelection;        

        public Course EnrolledCourseSelection
        {
            get { return enrolledCourseSelection; }
            set { enrolledCourseSelection = value; }
        }

        public void EnrollInCourse()
        {
            if (SelectedCourse != null && !AlreadyEnrolledInCourse(SelectedCourse))
            {
                CoursesEnrolledIn.Add(SelectedCourse);
            }
            else
            {
                // handle error
            }
        }

        private bool AlreadyEnrolledInCourse(Course course)
        {
            return CoursesEnrolledIn.Contains(course);
        }

        public void RemoveSelectedCourse()
        {
            CoursesEnrolledIn.Remove(EnrolledCourseSelection);
        }

        #endregion    
    }
}
