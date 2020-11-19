using Caliburn.Micro;
using SchoolDBUI.Library.Models;
using SchoolDBUI.Library.Models.SchoolBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SchoolDBUI.ViewModels.Components
{
    public class QualificationsAddControlViewModel : Screen, IHandle<Subject>
    {
        private readonly IEventAggregator eventAggregator;

        public QualificationsAddControlViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            eventAggregator.Subscribe(this);
        }

        // TODO: handle duplicate subjects

        public IEnumerable<Subject> Subjects
        {
            get
            {
                return Enum.GetValues(typeof(Subject))
                    .Cast<Subject>();
            }
        }

        private string selectedSubject;
        public string SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                selectedSubject = value;
                NotifyOfPropertyChange(() => SelectedSubject);
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

        private string selectedLevel;
        public string SelectedLevel
        {
            get { return selectedLevel; }
            set
            {
                selectedLevel = value;
                NotifyOfPropertyChange(() => SelectedLevel);
            }
        }

        private SubjectTeachersViewModel selectedQualification;

        public SubjectTeachersViewModel SelectedQualification
        {
            get { return selectedQualification; }
            set 
            {
                selectedQualification = value;
                NotifyOfPropertyChange(() => SelectedQualification);
            }
        }


        private BindingList<SubjectTeachersViewModel> qualifications = new BindingList<SubjectTeachersViewModel>();

        public BindingList<SubjectTeachersViewModel> Qualifications
        {
            get { return qualifications; }
            set
            {
                qualifications = value;
                NotifyOfPropertyChange(() => Qualifications);
            }
        }

        public void AddSubject()
        {
            if (Enum.TryParse(SelectedSubject, out Subject result) && Enum.TryParse(SelectedLevel, out CourseLevel level))
            {
                Qualifications.Add(new SubjectTeachersViewModel
                {
                    Subject = result,
                    CourseLevel = level
                });
            }
            // handle error}
        }

        public void RemoveSubject()
        {
            if (!string.IsNullOrWhiteSpace(SelectedSubject))
            {
                Qualifications.Remove(SelectedQualification);
            }
        }

        public void Handle(Subject subject)
        {
            if (Qualifications.Count > 0)
            {
                var qualification = Qualifications
                .Where(q => q.Subject == subject)
                .FirstOrDefault();

                if (qualification != null)
                {
                    eventAggregator.PublishOnUIThread(qualification);
                }                
            }
        }
    }
}
