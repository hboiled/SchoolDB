using Caliburn.Micro;
using SchoolDBUI.Library.API;
using SchoolDBUI.Library.Models;
using SchoolDBUI.ViewModels.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBUI.ViewModels
{
    public class StaffManagementViewModel : Screen
    {
        private readonly ITeacherEndpoint teacherEndpoint;
        private readonly ICourseEndpoint courseEndpoint;

        // Components
        public AddressAddControlViewModel AddressAddControlView { get; set; } = new AddressAddControlViewModel();
        public EmailAddControlViewModel EmailAddControlView { get; set; } = new EmailAddControlViewModel();
        public PhoneAddControlViewModel PhoneAddControlView { get; set; } = new PhoneAddControlViewModel();
        public QualificationsAddControlViewModel QualificationsAddControlView { get; set; } = new QualificationsAddControlViewModel();

        public StaffManagementViewModel(
            ITeacherEndpoint teacherEndpoint,
            ICourseEndpoint courseEndpoint
            )
        {
            this.teacherEndpoint = teacherEndpoint;
            this.courseEndpoint = courseEndpoint;

            AddressAddControlView = new AddressAddControlViewModel();
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
    }
}
