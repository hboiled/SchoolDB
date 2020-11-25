using Caliburn.Micro;
using SchoolDBUI.Library.API;
using SchoolDBUI.Library.Models;
using SchoolDBUI.Library.Models.Contact;
using SchoolDBUI.Library.Models.SchoolBusiness;
using SchoolDBUI.Library.Models.SubmitDTOs;
using SchoolDBUI.ViewModels.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBUI.ViewModels
{
    public class StaffManagementViewModel : Screen
    {
        private readonly ITeacherEndpoint teacherEndpoint;
        private ICourseEndpoint courseEndpoint;
        private IEventAggregator eventAggregator;

        // Components
        
        public AddressAddControlViewModel AddressAddControlView { get; set; } = new AddressAddControlViewModel();
        public EmailAddControlViewModel EmailAddControlView { get; set; } = new EmailAddControlViewModel();
        public PhoneAddControlViewModel PhoneAddControlView { get; set; } = new PhoneAddControlViewModel();
        public QualificationsAddControlViewModel QualificationsAddControlView { get; set; }
        public TeachersCoursesControlViewModel TeachersCoursesControlView { get; set; }
        // experiment: test to see if DI works with the above 2

        public StaffManagementViewModel(
            ITeacherEndpoint teacherEndpoint,
            ICourseEndpoint courseEndpoint,
            IEventAggregator eventAggregator
            )
        {
            this.teacherEndpoint = teacherEndpoint;
            this.courseEndpoint = courseEndpoint;
            this.eventAggregator = eventAggregator;

            TeachersCoursesControlView = new TeachersCoursesControlViewModel(courseEndpoint, eventAggregator);
            QualificationsAddControlView = new QualificationsAddControlViewModel(eventAggregator);

            LoadStaff();
        }

        private async Task LoadStaff()
        {
            List<Teacher> teachers = await teacherEndpoint.GetAll();
            Staff = null;
            Staff = new BindingList<Teacher>(teachers);
        }

        private string staffNameTextbox;

        public string StaffNameTextbox
        {
            get { return staffNameTextbox; }
            set 
            { 
                staffNameTextbox = value;
                NotifyOfPropertyChange(() => StaffNameTextbox);
            }
        }

        private Teacher selectedStaffMember;

        public Teacher SelectedStaffMember
        {
            get { return selectedStaffMember; }
            set 
            {
                selectedStaffMember = value;
                SetUpEditMode();
                NotifyOfPropertyChange(() => SelectedStaffMember);
            }
        }

        private void SetUpEditMode()
        {
            // placeholder val generation
            SelectedStaffMember.BirthDate = new DateTime(1980, 10, 11);
            SelectedStaffMember.StaffId = "T9800C";
            SelectedStaffMember.PhotoImgPath = "Placeholder";
            SelectedStaffMember.SubjectTeachers = new List<SubjectTeachersViewModel> 
                { new SubjectTeachersViewModel { CourseLevel = CourseLevel.Beginner, Subject = Subject.Maths } };
            SelectedStaffMember.Addresses = new List<Address> {
                new Address { City="abc",Postcode="12",State="a",Suburb="vc",IsPrimary=true,StreetAddress="asv" } };
            SelectedStaffMember.Emails = new List<Email> { new Email { EmailAddress = "af", IsSchoolEmail = true, Owner = EmailOwner.Guardian } };
            SelectedStaffMember.PhoneNumbers = new List<PhoneNum> { 
                new PhoneNum { IsEmergency = true, Number = "a", IsMobile = false, Owner = PhoneNumberOwner.Home } };

            if (SelectedStaffMember != null)
            {
                // NULL CHECK!!
                //EnableEditMode();
                FirstNameTextbox = SelectedStaffMember.FirstName;
                LastNameTextbox = SelectedStaffMember.LastName;
                DOBPicker = SelectedStaffMember.BirthDate;
                AgeTextbox = SelectedStaffMember.Age.ToString();
                SalaryTextbox = SelectedStaffMember.Salary.ToString();
                StaffPhotoTextbox = SelectedStaffMember.PhotoImgPath;
                StaffIdTextbox = SelectedStaffMember.StaffId;
                SelectedGender = SelectedStaffMember.Gender;
                QualificationsAddControlView.Qualifications = new BindingList<SubjectTeachersViewModel>(SelectedStaffMember.SubjectTeachers);
                AddressAddControlView.Addresses = new BindingList<Address>(SelectedStaffMember.Addresses);
                EmailAddControlView.Emails = new BindingList<Email>(SelectedStaffMember.Emails);
                PhoneAddControlView.PhoneNums = new BindingList<PhoneNum>(SelectedStaffMember.PhoneNumbers);
            };
        }

        // To be revamped into type of IStaff?
        private BindingList<Teacher> staff;
        public BindingList<Teacher> Staff 
        { 
            get { return staff; } 
            set
            {
                staff = value;
                NotifyOfPropertyChange(() => Staff);
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

        public void AddStaff()
        {
            var teacher = new TeacherSubmitDTO
            {
                FirstName = "faf",
                LastName = "af",
                SubjectTeachers = new List<SubjectTeachersViewModel>
                {
                    new SubjectTeachersViewModel {CourseLevel = CourseLevel.Intermediate, Subject = Subject.Biology}
                },
                CoursesTaught = new List<Course>
                {
                    new Course
                    {
                        Id = 1
                    },
                    new Course
                    {
                        Id = 2
                    }
                }                
            };

            teacherEndpoint.SubmitTeacher(teacher);
        }

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

        private string staffPhotoTextbox;

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


        #endregion
    }
}
