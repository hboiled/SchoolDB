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
    public class StudentSubmitViewModel : Screen
    {
        private readonly IStudentEndpoint studentEndpoint;

        public StudentSubmitViewModel(IStudentEndpoint studentEndpoint)
        {
            this.studentEndpoint = studentEndpoint;
        }

        private Subject selectedSubjectFilter;
        public Subject SelectedSubjectFilter
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
            var courses = await studentEndpoint.GetCoursesBySubject(SelectedSubjectFilter);
            FilteredCourses = new BindingList<Course>(courses);
            
        }

        public bool FilterNotSelected { 
            get
            {
                //NotifyOfPropertyChange(() => FilterNotSelected);
                return filteredCourses.Count != 0;
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

        public void EnrollInCourse()
        {
            CoursesEnrolledIn.Add(new Course
            {
                Id = 1,
                Subject = Subject.Biology.ToString(),
                Title = "Test",
                CourseId = "L905HJK"
            });
        }

    }
}
