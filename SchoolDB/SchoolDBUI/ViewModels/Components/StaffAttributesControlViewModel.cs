using Caliburn.Micro;
using SchoolDBUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolDBUI.ViewModels.Components
{
    public class StaffAttributesControlViewModel : Screen
    {
        #region Staff Attributes

        private string firstNameTextbox;

        public string FirstNameTextbox
        {
            get { return firstNameTextbox; }
            set
            {
                firstNameTextbox = value;
                NotifyOfPropertyChange(() => FirstNameTextbox);
            }
        }

        private string lastNameTextbox;

        public string LastNameTextbox
        {
            get { return lastNameTextbox; }
            set
            {
                lastNameTextbox = value;
                NotifyOfPropertyChange(() => LastNameTextbox);
            }
        }

        private DateTime dobPicker;

        public DateTime DOBPicker
        {
            get { return dobPicker; }
            set
            {
                dobPicker = value;
                NotifyOfPropertyChange(() => DOBPicker);
            }
        }

        private string ageTextbox;

        public string AgeTextbox
        {
            get { return ageTextbox; }
            set
            {
                ageTextbox = value;
                NotifyOfPropertyChange(() => AgeTextbox);
            }
        }

        private string salaryTextbox;

        public string SalaryTextbox
        {
            get { return salaryTextbox; }
            set
            {
                salaryTextbox = value;
                NotifyOfPropertyChange(() => SalaryTextbox);
            }
        }

        private string staffPhotoTextbox = @"http://web.engr.oregonstate.edu/~johnstom/img/people/placeholder.png";

        public string StaffPhotoTextbox
        {
            get { return staffPhotoTextbox; }
            set
            {
                staffPhotoTextbox = value;
                NotifyOfPropertyChange(() => StaffPhotoTextbox);
            }
        }

        private string staffIdTextbox;

        public string StaffIdTextbox
        {
            get { return staffIdTextbox; }
            set
            {
                staffIdTextbox = value;
                NotifyOfPropertyChange(() => StaffIdTextbox);
            }
        }

        private Gender selectedGender;

        public Gender SelectedGender
        {
            get { return selectedGender; }
            set
            {
                selectedGender = value;
                NotifyOfPropertyChange(() => SelectedGender);
            }
        }

        public IEnumerable<Gender> Genders
        {
            get
            {
                return Enum.GetValues(typeof(Gender))
                    .Cast<Gender>();
            }
        }

        #endregion
    }
}
