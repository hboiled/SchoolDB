using Caliburn.Micro;
using SchoolDBUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolDBUI.ViewModels.StaffManagement
{
    public class StaffAttributesControlViewModel : Screen
    {
        private Teacher selectedStaffMember;

        public Teacher SelectedStaffMember
        {
            get { return selectedStaffMember; }
            set
            {
                selectedStaffMember = value;
                NotifyOfPropertyChange(() => SelectedStaffMember);
            }
        }


        #region Staff Attributes

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
