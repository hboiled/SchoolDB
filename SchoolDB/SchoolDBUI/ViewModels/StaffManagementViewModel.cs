using Caliburn.Micro;
using SchoolDBUI.Library.API;
using SchoolDBUI.Library.Models;
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
                NotifyOfPropertyChange(() => SelectedStaffMember);
            }
        }

        // To be revamped into type of IStaff
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
