using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private IEventAggregator events;
        private readonly SchoolDataViewModel schoolDataViewModel;

        //private IAPIHelper _apiHelper;

        public ShellViewModel(IEventAggregator events, SchoolDataViewModel schoolDataViewModel)
        {
            this.events = events;
            this.schoolDataViewModel = schoolDataViewModel;
            this.events.Subscribe(this);

            // IoC inversion of control container can be accessed without the simple container for DI
            ActivateItem(IoC.Get<SchoolDataViewModel>());            
        }
    }
}
