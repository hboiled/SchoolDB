﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private IEventAggregator events;
        private readonly StudentDataViewModel studentDataViewModel;
        private readonly StudentSubmitViewModel studentSubmitViewModel;
        private readonly CourseManagementViewModel courseManagementViewModel;

        //private IAPIHelper _apiHelper;

        public ShellViewModel(IEventAggregator events, 
            StudentDataViewModel studentDataViewModel, 
            StudentSubmitViewModel studentSubmitViewModel,
            CourseManagementViewModel courseManagementViewModel)
        {
            this.events = events;
            this.studentDataViewModel = studentDataViewModel;
            this.studentSubmitViewModel = studentSubmitViewModel;
            this.courseManagementViewModel = courseManagementViewModel;
            this.events.Subscribe(this);

            // IoC inversion of control container can be accessed without the simple container for DI
            ActivateItem(IoC.Get<StudentSubmitViewModel>());            
            //ActivateItem(IoC.Get<StudentDataViewModel>());
        }

        public void ViewStudentData()
        {
            ActivateItem(IoC.Get<StudentDataViewModel>());
        }

        public void AddStudentData()
        {
            ActivateItem(IoC.Get<StudentSubmitViewModel>());
        }

        public void CourseManagementView()
        {
            ActivateItem(IoC.Get<CourseManagementViewModel>());
        }

        public void ExitApplication()
        {
            TryClose();
        }
    }
}
