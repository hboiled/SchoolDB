using Caliburn.Micro;
using Microsoft.Win32;
using SchoolDBUI.Library.API;
using SchoolDBUI.Library.Models;
using SchoolDBUI.Library.Models.Contact;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace SchoolDBUI.ViewModels
{
    public class StudentSubmitViewModel : Screen
    {
        private readonly IStudentEndpoint studentEndpoint;

        public StudentSubmitViewModel(IStudentEndpoint studentEndpoint)
        {
            this.studentEndpoint = studentEndpoint;            
            StudentPhoto = @"http://web.engr.oregonstate.edu/~johnstom/img/people/placeholder.png";
        }

        public string FullName 
        { 
            get
            {
                return $"{FirstNameTextbox} {LastNameTextbox}";
            }
        }

        private string firstName;
        public string FirstNameTextbox 
        {
            get { return firstName; }
            set
            {
                firstName = value;
                NotifyOfPropertyChange(() => FullName);
            }
        }

        private string lastName;
        public string LastNameTextbox
        {
            get { return lastName; }
            set
            {
                lastName = value;
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public DateTime StudentDOB { get; set; }

        public Gender SelectedGender { get; set; }

        public IEnumerable<Gender> Genders
        {
            get
            {
                return Enum.GetValues(typeof(Gender))
                    .Cast<Gender>();
            }
        }

        private string studentPhoto;

        public string StudentPhoto
        {
            get { return studentPhoto; }
            set
            {
                studentPhoto = value;
                NotifyOfPropertyChange(() => StudentPhoto);
            }
        }

        public void UploadPhoto()
        {
            // TODO: put restrictions on photo size or crop image

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a photo";
            openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.InitialDirectory = "C:\\Users\\61406\\Pictures\\posters"; // default value set for testing

            if (openFileDialog.ShowDialog() == true) // cleaner, more logical way of doing this?
            {
                StudentPhoto = openFileDialog.FileName;
            }

        }

        public int SelectedGrade { get; set; }

        public IEnumerable<int> Grades
        {
            get
            {
                return new List<int>()
                {
                    7, 8, 9, 10, 11, 12
                };
            }
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
        public string StreetAddressTextbox { get; set; }
        public string PostcodeTextbox { get; set; }
        public string SuburbTextbox { get; set; }
        public string CityTextbox { get; set; }
        public string StateTextbox { get; set; }
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
                StreetAddress = StreetAddressTextbox,
                Suburb = SuburbTextbox,
                City = CityTextbox,
                State = StateTextbox,
                Postcode = PostcodeTextbox,
                IsPrimary = PrimaryAddressBox
            };

            Addresses.Add(address);
        }


        #endregion

        // Add remove functionality
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

        // Add remove functionality
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

        public bool EContactBox { get; set; }
        public bool MobileBox { get; set; }

        public PhoneNumberOwner SelectedPhoneOwner { get; set; }

        private BindingList<PhoneNum> phoneNums = new BindingList<PhoneNum>();

        public BindingList<PhoneNum> PhoneNums
        {
            get { return phoneNums; }
            set { phoneNums = value; }
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
        }

        public void RemovePhoneNumber()
        {

        }

        private void ResetPhoneNumberTextbox()
        {
            PhoneNumberTextbox = "";
        }

        #endregion

        public void SubmitStudent()
        {
            // CREATE
            var student = new StudentSubmitDTO
            {
                FirstName = FirstNameTextbox,
                LastName = LastNameTextbox,
                Gender = SelectedGender,
                PhotoImgPath = StudentPhoto, // casing??
                Grade = SelectedGrade,
                BirthDate = StudentDOB,
                Emails = Emails.ToList(),
                PhoneNums = PhoneNums.ToList(),
                Addresses = Addresses.ToList(),
                CourseEnrollments = CoursesEnrolledIn.ToList(),                
            };

            // hack to remove circular references, must be reworked
            foreach (var item in student.CourseEnrollments)
            {
                item.Students.Clear();
                item.Teacher = null;
            }

            studentEndpoint.SubmitStudent(student);
        }
    }
}
