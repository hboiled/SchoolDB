using Caliburn.Micro;
using SchoolDBUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolDBUI.ViewModels
{
    public class StudentSubmitViewModel : Screen
    {
        private Subject selectedSubjectFilter;
        public Subject SelectedSubjectFilter
        {
            get { return selectedSubjectFilter; }
            set
            {
                selectedSubjectFilter = value;
                NotifyOfPropertyChange(() => SelectedSubjectFilter);
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
    }
}
