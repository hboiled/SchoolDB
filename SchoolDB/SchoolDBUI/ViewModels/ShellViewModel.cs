using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows;

namespace SchoolDBUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private IEventAggregator events;
        private readonly StudentDataViewModel studentDataViewModel;
        private readonly StudentSubmitViewModel studentSubmitViewModel;
        private readonly CourseManagementViewModel courseManagementViewModel;
        private readonly StaffManagementViewModel staffManagementViewModel;

        private bool isStudentView;
        public bool IsStudentView
        {
            get { return isStudentView; }
            set
            {
                isStudentView = value;
                NotifyOfPropertyChange(() => IsStudentView);
            }
        }

        private bool isStudentSubmit;
        public bool IsStudentSubmit
        {
            get { return isStudentSubmit; }
            set 
            { 
                isStudentSubmit = value;
                NotifyOfPropertyChange(() => IsStudentSubmit);
            }
        }

        private bool isCourseManagement;
        public bool IsCourseManagement
        {
            get { return isCourseManagement; }
            set
            {
                isCourseManagement = value;
                NotifyOfPropertyChange(() => IsCourseManagement);
            }
        }

        private bool isStaffManagement;
        public bool IsStaffManagement
        {
            get { return isStaffManagement; }
            set
            {
                isStaffManagement = value;
                NotifyOfPropertyChange(() => IsStaffManagement);
            }
        }

        public ShellViewModel(IEventAggregator events, 
            StudentDataViewModel studentDataViewModel, 
            StudentSubmitViewModel studentSubmitViewModel,
            CourseManagementViewModel courseManagementViewModel,
            StaffManagementViewModel staffManagementViewModel)
        {
            this.events = events;
            this.studentDataViewModel = studentDataViewModel;
            this.studentSubmitViewModel = studentSubmitViewModel;
            this.courseManagementViewModel = courseManagementViewModel;
            this.staffManagementViewModel = staffManagementViewModel;
            this.events.Subscribe(this);

            // IoC inversion of control container can be accessed without the simple container for DI
            IsStaffManagement = true;
            ActivateItem(IoC.Get<StaffManagementViewModel>());
        }

        public void ViewStudentData()
        {
            SetAllFlagsFalse();
            IsStudentView = true;
            ActivateItem(IoC.Get<StudentDataViewModel>());
        }

        public void AddStudentData()
        {
            SetAllFlagsFalse();
            IsStudentSubmit = true;
            ActivateItem(IoC.Get<StudentSubmitViewModel>());
        }

        public void CourseManagementView()
        {
            SetAllFlagsFalse();
            IsCourseManagement = true;
            ActivateItem(IoC.Get<CourseManagementViewModel>());            
        }

        public void StaffManagementView()
        {
            SetAllFlagsFalse();
            IsStaffManagement = true;
            ActivateItem(IoC.Get<StaffManagementViewModel>());
        }

        private void SetAllFlagsFalse()
        {
            IsStudentView = false;
            IsStudentSubmit = false;
            IsCourseManagement = false;
            IsStaffManagement = false;
        }


        public void CourseKeyEvent(KeyEventArgs keyArgs)
        {
            // find way to stop firing the event if not command?
            if (IsCourseManagement)
            {
                if (Keyboard.Modifiers == ModifierKeys.Control && keyArgs.Key == Key.N)
                {
                    AddNewCourse();
                }

                if (Keyboard.Modifiers == ModifierKeys.Control && keyArgs.Key == Key.S)
                {
                    SaveCourse();
                }
            }
        }

        private void SaveCourse()
        {
            events.PublishOnUIThread("SaveCourse");
        }

        public void AddNewCourse()
        {
            // order matters, otherwise event will be handled first then a new instance of the view will be created
            CourseManagementView();
            events.PublishOnUIThread("NewCourse");            
        }

        public void StaffKeyEvent(KeyEventArgs keyArgs)
        {
            if (IsStaffManagement)
            {
                if (Keyboard.Modifiers == ModifierKeys.Control && keyArgs.Key == Key.N)
                {
                    AddNewStaff();
                }

                if (Keyboard.Modifiers == ModifierKeys.Control && keyArgs.Key == Key.S)
                {
                    SaveStaff();
                }
            }
        }

        private void SaveStaff()
        {
            events.PublishOnUIThread("SaveStaff");
        }

        public void AddNewStaff()
        {            
            StaffManagementView();
            events.PublishOnUIThread("NewStaff");
        }

        public void ExitApplication()
        {
            TryClose();
        }
    }
}
