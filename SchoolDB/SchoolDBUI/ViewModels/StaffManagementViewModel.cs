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

        private bool IsEditMode = false;

        // Components
        public StaffAttributesControlViewModel StaffAttributesControlView { get; set; } = new StaffAttributesControlViewModel();
        public AddressAddControlViewModel AddressAddControlView { get; set; } = new AddressAddControlViewModel();
        public EmailAddControlViewModel EmailAddControlView { get; set; } = new EmailAddControlViewModel();
        public PhoneAddControlViewModel PhoneAddControlView { get; set; } = new PhoneAddControlViewModel();
        public QualificationsAddControlViewModel QualificationsAddControlView { get; set; }
        public TeachersCoursesControlViewModel TeachersCoursesControlView { get; set; }

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

        private string modeMsg;

        public string ModeMsg // upon submit, clear msg
        {
            get { return modeMsg; }
            set
            {
                modeMsg = value;
                NotifyOfPropertyChange(() => ModeMsg);
            }
        }

        public void Handle(string message)
        {
            if (message.Equals("NewStaff"))
            {
                ModeMsg = "Add New Staff";
                IsEditMode = false;
            }

            if (message.Equals("SaveStaff"))
            {
                AddStaff();
            }
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
            
            if (SelectedStaffMember != null)
            {
                // NULL CHECK!!
                EnableEditMode();
                StaffAttributesControlView.FirstNameTextbox = SelectedStaffMember.FirstName;
                StaffAttributesControlView.LastNameTextbox = SelectedStaffMember.LastName;
                StaffAttributesControlView.DOBPicker = SelectedStaffMember.BirthDate;
                StaffAttributesControlView.AgeTextbox = SelectedStaffMember.Age.ToString();
                StaffAttributesControlView.SalaryTextbox = SelectedStaffMember.Salary.ToString();
                StaffAttributesControlView.StaffPhotoTextbox = SelectedStaffMember.PhotoImgPath;
                StaffAttributesControlView.StaffIdTextbox = SelectedStaffMember.StaffId;
                StaffAttributesControlView.SelectedGender = SelectedStaffMember.Gender;
                QualificationsAddControlView.Qualifications = new BindingList<SubjectTeachersViewModel>(SelectedStaffMember.SubjectTeachers);
                AddressAddControlView.Addresses = new BindingList<Address>(SelectedStaffMember.Addresses);
                EmailAddControlView.Emails = new BindingList<Email>(SelectedStaffMember.Emails);
                PhoneAddControlView.PhoneNums = new BindingList<PhoneNum>(SelectedStaffMember.PhoneNumbers);
                TeachersCoursesControlView.CoursesTaught = new BindingList<Course>(SelectedStaffMember.CoursesTaught);
            };
        }

        private void EnableEditMode()
        {
            ModeMsg = "Edit Staff";
            IsEditMode = true;
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

        
    }
}
