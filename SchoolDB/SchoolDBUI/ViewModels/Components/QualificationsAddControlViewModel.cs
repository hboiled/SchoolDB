using Caliburn.Micro;
using SchoolDBUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SchoolDBUI.ViewModels.Components
{
    public class QualificationsAddControlViewModel : Screen
    {
        // TODO: display subjects in listview, handle duplicate subjects

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

        private Subject selectedQualification;

        public Subject SelectedQualification
        {
            get { return selectedQualification; }
            set 
            {
                selectedQualification = value;
                NotifyOfPropertyChange(() => SelectedQualification);
            }
        }


        private BindingList<Subject> qualifications = new BindingList<Subject>();
        public BindingList<Subject> Qualifications
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
            if (Enum.TryParse(SelectedSubject, out Subject result))
            {
                Qualifications.Add(result);
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
    }
}
