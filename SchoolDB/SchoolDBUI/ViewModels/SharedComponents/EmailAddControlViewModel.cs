using Caliburn.Micro;
using SchoolDBUI.Library.Models.Contact;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SchoolDBUI.ViewModels.SharedComponents
{
    public class EmailAddControlViewModel : Screen
    {
        #region Email

        private string emailAddressTextbox;
        public string EmailAddressTextbox
        {
            get { return emailAddressTextbox; }
            set
            {
                emailAddressTextbox = value;
                // must notify of prop change, using full prop to have UI update to changes
                NotifyOfPropertyChange(() => EmailAddressTextbox);
            }
        }
        public EmailOwner SelectedEmailOwner { get; set; }

        public IEnumerable<EmailOwner> EmailOwnerTypes
        {
            get
            {
                return Enum.GetValues(typeof(EmailOwner))
                    .Cast<EmailOwner>();
            }
        }

        private BindingList<Email> emails = new BindingList<Email>();

        public BindingList<Email> Emails
        {
            get { return emails; }
            set
            {
                emails = value;
                NotifyOfPropertyChange(() => Emails);
            }
        }

        public void AddEmail()
        {
            if (!string.IsNullOrWhiteSpace(EmailAddressTextbox))
            {
                Emails.Add(new Email
                {
                    EmailAddress = EmailAddressTextbox,
                    Owner = SelectedEmailOwner
                });
            }

            ClearEmailFormFields();
        }

        private void ClearEmailFormFields()
        {
            EmailAddressTextbox = "";
        }

        public Email SelectedEmail { get; set; }

        public void RemoveEmail()
        {
            if (SelectedEmail != null)
            {
                Emails.Remove(SelectedEmail);
            }
        }

        #endregion
    }
}
