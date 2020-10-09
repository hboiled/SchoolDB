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

        //private IAPIHelper _apiHelper;

        public ShellViewModel(IEventAggregator events, StudentDataViewModel studentDataViewModel)
        {
            this.events = events;
            this.studentDataViewModel = studentDataViewModel;
            this.events.Subscribe(this);

            // IoC inversion of control container can be accessed without the simple container for DI
            ActivateItem(IoC.Get<StudentDataViewModel>());            
        }
    }
}