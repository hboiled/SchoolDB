using Caliburn.Micro;
using SchoolDBUI.EventCommands;
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
    public class StaffManagementViewModel : Screen, IHandle<StaffCommand>
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

            SetUpNewStaffMode();

            LoadStaff();
        }

        #region Mode Change
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

        public void Handle(StaffCommand cmd)
        {
            if (cmd == StaffCommand.NewStaff)
            {
                SetUpNewStaffMode();
            }

            if (cmd == StaffCommand.SaveStaff)
            {
                AddStaff();
            }
        }

        private void SetUpNewStaffMode()
        {
            ModeMsg = "Add New Staff";
            IsEditMode = false;

            // wire up attributes control with current model
            // new instance is initialised from shell view, so selected teacher resets
            StaffAttributesControlView.SelectedStaffMember = SelectedStaffMember;
        }
        #endregion

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

        private Teacher selectedStaffMember = new Teacher();

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

                // binding is set up in control
                StaffAttributesControlView.SelectedStaffMember = SelectedStaffMember; 
               
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
            /// * Need to make SelectedStaffMember compatible with create teacher
            var teacher = new TeacherSubmitDTO
            {
                FirstName = StaffAttributesControlView.SelectedStaffMember.FirstName,
                LastName = StaffAttributesControlView.SelectedStaffMember.LastName,
                Gender = StaffAttributesControlView.SelectedStaffMember.Gender,
                Salary = StaffAttributesControlView.SelectedStaffMember.Salary,
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

        protected override void OnActivate()
        {
            eventAggregator.Subscribe(this);
            base.OnActivate();
        }

        protected override void OnDeactivate(bool close)
        {
            eventAggregator.Unsubscribe(this);
            base.OnDeactivate(close);
        }
    }
}
