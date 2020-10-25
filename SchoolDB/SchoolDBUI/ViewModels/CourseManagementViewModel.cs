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
        private readonly ITeacherEndpoint teacherEndpoint;
        public CourseManagementViewModel(ITeacherEndpoint teacherEndpoint)
        {
            this.teacherEndpoint = teacherEndpoint;
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
                var courses = await teacherEndpoint.GetTeachersBySubject(subject);
                FilterNotSelected = courses.Count != 0;
                FilteredTeachers = new BindingList<Teacher>(courses);
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
    }
}
