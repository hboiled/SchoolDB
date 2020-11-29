using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows;
using SchoolDBUI.EventCommands;

namespace SchoolDBUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private IEventAggregator eventAggregator;
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
            this.eventAggregator = events;
            this.studentDataViewModel = studentDataViewModel;
            this.studentSubmitViewModel = studentSubmitViewModel;
            this.courseManagementViewModel = courseManagementViewModel;
            this.staffManagementViewModel = staffManagementViewModel;
            this.eventAggregator.Subscribe(this);

            // IoC inversion of control container can be accessed without the simple container for DI
            StaffManagementView();
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
            eventAggregator.PublishOnUIThread(CourseCommand.SaveCourse);
        }

        public void AddNewCourse()
        {
            // order matters, otherwise event will be handled first then a new instance of the view will be created
            CourseManagementView();
            eventAggregator.PublishOnUIThread(CourseCommand.NewCourse);            
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
            eventAggregator.PublishOnUIThread(StaffCommand.SaveStaff);
        }

        public void AddNewStaff()
        {            
            StaffManagementView();
            eventAggregator.PublishOnUIThread(StaffCommand.NewStaff);
        }

        public void ExitApplication()
        {
            TryClose();
        }

        //protected override void OnActivate()
        //{
        //    eventAggregator.Subscribe(this);
        //    base.OnActivate();
        //}

        //protected override void OnDeactivate(bool close)
        //{
        //    eventAggregator.Unsubscribe(this);
        //    base.OnDeactivate(close);
        //}
    }
}
