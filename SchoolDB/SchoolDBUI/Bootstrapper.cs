using AutoMapper;
using Caliburn.Micro;
using SchoolDBUI.Library.API;
using SchoolDBUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SchoolDBUI
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }

        //private IMapper ConfigureAutomapper()
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<ProductModel, ProductDisplayModel>();
        //        cfg.CreateMap<CartItemModel, CartItemDisplayModel>();
        //    });

        //    return config.CreateMapper();
        //}

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            // Inits base view model with corresponding view, 
            // whose ctor must be parameterless (the one with initialize method call)
            DisplayRootViewFor<ShellViewModel>();
        }

        // DI container
        // Sets an instance of itself to itself, passes out this reference to requesting components
        protected override void Configure()
        {
            container.Instance(container)
                .PerRequest<IStudentEndpoint, StudentEndpoint>()
                ;

            // Get from caliburn micro, a singleton of WindowManager and EventAggregator
            container
                // specify interface, provide implementation
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IAPIHelper, APIHelper>()
                ;

            // reflection on current application instance
            GetType().Assembly.GetTypes()
                // get types that are classes and end with view model
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                // 
                .ForEach(viewModelType => container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        // Caliburn micro set up DI for an instance
        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        // Caliburn micro set up DI for instances
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
    }
}
