using Caliburn.Micro;
using SchoolDBUI.Library.Models.Contact;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SchoolDBUI.ViewModels.Components
{
    public class PhoneAddControlViewModel : Screen
    {// 
        #region Phone

        private string phoneNumberTextbox;
        public string PhoneNumberTextbox
        {
            get { return phoneNumberTextbox; }
            set
            {
                phoneNumberTextbox = value;
                NotifyOfPropertyChange(() => PhoneNumberTextbox);
            }
        }

        private bool eContactBox;
        public bool EContactBox
        {
            get { return eContactBox; }
            set
            {
                eContactBox = value;
                NotifyOfPropertyChange(() => EContactBox);
            }
        }

        private bool mobileBox;
        public bool MobileBox
        {
            get { return mobileBox; }
            set
            {
                mobileBox = value;
                NotifyOfPropertyChange(() => MobileBox);
            }
        }

        public PhoneNumberOwner SelectedPhoneOwner { get; set; }

        private BindingList<PhoneNum> phoneNums = new BindingList<PhoneNum>();

        public BindingList<PhoneNum> PhoneNums
        {
            get { return phoneNums; }
            set 
            { 
                phoneNums = value;
                NotifyOfPropertyChange(() => PhoneNums);
            }
        }

        public IEnumerable<PhoneNumberOwner> PhoneOwnerTypes
        {
            get
            {
                return Enum.GetValues(typeof(PhoneNumberOwner))
                    .Cast<PhoneNumberOwner>();
            }
        }

        public void AddPhoneNumber()
        {
            if (!string.IsNullOrWhiteSpace(PhoneNumberTextbox))
            {
                phoneNums.Add(
                    new PhoneNum
                    {
                        Number = PhoneNumberTextbox,
                        IsMobile = MobileBox,
                        IsEmergency = EContactBox,
                        Owner = SelectedPhoneOwner
                    });
            }
            ResetPhoneNumberTextbox();
        }

        public PhoneNum SelectedPhoneNumber { get; set; }

        public void RemovePhoneNumber()
        {
            if (SelectedPhoneNumber != null)
            {
                PhoneNums.Remove(SelectedPhoneNumber);
            }
            ResetPhoneNumberTextbox();
        }

        private void ResetPhoneNumberTextbox()
        {
            PhoneNumberTextbox = "";
            EContactBox = false;
            MobileBox = false;
        }

        #endregion
    }
}
