using Caliburn.Micro;
using SchoolDBUI.Library.API;
using SchoolDBUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBUI.ViewModels.StudentManagement
{
    public class StudentDataViewModel : Screen
    {
        private readonly IStudentEndpoint studentEndpoint;

        public StudentDataViewModel(IStudentEndpoint studentEndpoint)
        {
            this.studentEndpoint = studentEndpoint;
            LoadStudents();
        }

        private async Task LoadStudents()
        {
            var studentList = await studentEndpoint.GetAll();

            Students = new BindingList<Student>(studentList);
        }

        private BindingList<Student> students;

        public BindingList<Student> Students
        {
            get { return students; }
            set
            {
                students = value;
                NotifyOfPropertyChange(() => Students);
            }
        }

        private Student selectedStudent;

        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                NotifyOfPropertyChange(() => SelectedStudent);
            }
        }

        private string studentNameTextBox;

        public string StudentNameTextbox
        {
            get { return studentNameTextBox; }
            set
            {
                studentNameTextBox = value;
                SearchStudents();
            }
        }

        private async Task SearchStudents()
        {
            var filteredStudents = await studentEndpoint.SearchStudent(StudentNameTextbox);

            Students = new BindingList<Student>(filteredStudents);
        }


    }
}
