using Caliburn.Micro;
using SchoolDBUI.Library.API;
using SchoolDBUI.Library.Models;
using SchoolDBUI.Library.Models.Contact;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolDBUI.ViewModels
{
    public class StudentSubmitViewModel : Screen
    {
        private readonly IStudentEndpoint studentEndpoint;

        public StudentSubmitViewModel(IStudentEndpoint studentEndpoint)
        {
            this.studentEndpoint = studentEndpoint;
        }

        // Email

        // Phone

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
                var courses = await studentEndpoint.GetCoursesBySubject(subject);
                FilterNotSelected = courses.Count != 0;
                FilteredCourses = new BindingList<Course>(courses);
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

        private Course selectedCourse;

        public Course SelectedCourse
        {
            get { return selectedCourse; }
            set { selectedCourse = value; }
        }

        private Course enrolledCourseSelection;

        public Course EnrolledCourseSelection
        {
            get { return enrolledCourseSelection; }
            set { enrolledCourseSelection = value; }
        }

        public void EnrollInCourse()
        {
            if (SelectedCourse != null && !AlreadyEnrolledInCourse(SelectedCourse))
            {
                CoursesEnrolledIn.Add(SelectedCourse);
            }
            else
            {
                // handle error
            }
        }

        private bool AlreadyEnrolledInCourse(Course course)
        {
            return CoursesEnrolledIn.Contains(course);
        }

        public void RemoveSelectedCourse()
        {
            CoursesEnrolledIn.Remove(EnrolledCourseSelection);
        }

        #endregion

        // Add remove address functionality
        #region Addresses
        public string StreetAddress { get; set; }
        public string Postcode { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool PrimaryAddressBox { get; set; }

        private BindingList<Address> addresses = new BindingList<Address>();

        public BindingList<Address> Addresses
        {
            get { return addresses; }
            set { addresses = value; }
        }


        public void AddAddress()
        {
            var address = new Address
            {
                StreetAddress = StreetAddress,
                Suburb = Suburb,
                City = City,
                State = State,
                Postcode = Postcode,
                IsPrimary = PrimaryAddressBox
            };

            Addresses.Add(address);
        }


        #endregion

        #region Email

        private string emailAddressTextbox;
        public string EmailAddressTextbox {
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
            set { emails = value; }
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

        public void RemoveEmail()
        {

        }

        #endregion

        #region Phone
        public IEnumerable<PhoneNumberOwner> PhoneOwnerTypes
        {
            get
            {
                return Enum.GetValues(typeof(PhoneNumberOwner))
                    .Cast<PhoneNumberOwner>();
            }
        }

        #endregion
    }
}
