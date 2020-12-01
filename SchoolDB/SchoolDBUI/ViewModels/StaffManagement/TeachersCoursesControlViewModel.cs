using Caliburn.Micro;
using SchoolDBUI.Library.API;
using SchoolDBUI.Library.Models;
using SchoolDBUI.Library.Models.SchoolBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBUI.ViewModels.StaffManagement
{
    public class TeachersCoursesControlViewModel : Screen, IHandle<SubjectTeachersViewModel>
    {
        public SubjectTeachersViewModel receivedQualification { get; set; }

        private readonly ICourseEndpoint courseEndpoint;
        private readonly IEventAggregator eventAggregator;
        public TeachersCoursesControlViewModel(ICourseEndpoint courseEndpoint, IEventAggregator eventAggregator)
        {
            this.courseEndpoint = courseEndpoint;
            this.eventAggregator = eventAggregator;
            eventAggregator.Subscribe(this);
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

                await eventAggregator.PublishOnUIThreadAsync(subject);
                var filteredCourses = FilterCoursesByLevel(courses, subject);

                FilteredCourses = new BindingList<Course>(filteredCourses);
            }
            else
            {
                // handler error
            }

        }

        private List<Course> FilterCoursesByLevel(List<Course> courses, Subject subject)
        {
            //var qualification = new SubjectTeachersViewModel();

            return courses
                .Where(c => c.CourseLevel <= receivedQualification.CourseLevel)
                .ToList();
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

        private BindingList<Course> coursesTaught = new BindingList<Course>();

        public BindingList<Course> CoursesTaught
        {
            get { return coursesTaught; }
            set
            {
                coursesTaught = value;
                NotifyOfPropertyChange(() => CoursesTaught);
            }
        }

        private Course selectedCourse;

        public Course SelectedCourse
        {
            get { return selectedCourse; }
            set { selectedCourse = value; }
        }

        private Course selectedTaughtCourse;


        public Course SelectedTaughtCourse
        {
            get { return selectedTaughtCourse; }
            set { selectedTaughtCourse = value; }
        }

        public ICourseEndpoint CourseEndpoint { get; }

        public void AddCourse()
        {
            if (SelectedCourse != null && !CoursePresentInList(SelectedCourse))
            {
                CoursesTaught.Add(SelectedCourse);
            }
            else
            {
                // handle error
            }
        }

        private bool CoursePresentInList(Course course)
        {
            return CoursesTaught.Contains(course);
        }

        public void RemoveCourse()
        {
            CoursesTaught.Remove(SelectedTaughtCourse);
        }

        public void Handle(SubjectTeachersViewModel st)
        {
            receivedQualification = st;
        }

        #endregion

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
