using Caliburn.Micro;
using SchoolDBUI.Library.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBUI.ViewModels
{
    public class StudentDataViewModel : Screen
    {
        private readonly IStudentEndpoint studentEndpoint;

        public StudentDataViewModel(IStudentEndpoint studentEndpoint)
        {
            this.studentEndpoint = studentEndpoint;                        
        }

        public async Task TestMethod()
        {
            var x = await this.studentEndpoint.GetAll();
            Console.WriteLine();
        }
    }
}
