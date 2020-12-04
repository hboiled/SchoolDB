using Caliburn.Micro;
using Microsoft.Win32;
using SchoolDBUI.Library.API;
using SchoolDBUI.Library.Models;
using SchoolDBUI.Library.Models.SubmitDTOs;
using SchoolDBUI.ViewModels.SharedComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDBUI.ViewModels.StudentManagement
{
    public class StudentSubmitViewModel : Screen
    {
        private readonly IStudentEndpoint studentEndpoint;
        private readonly ICourseEndpoint courseEndpoint;

        // Components
        public AddressAddControlViewModel AddressAddControlView { get; set; } = new AddressAddControlViewModel();
        public EmailAddControlViewModel EmailAddControlView { get; set; } = new EmailAddControlViewModel();
        public PhoneAddControlViewModel PhoneAddControlView { get; set; } = new PhoneAddControlViewModel();
        public StudentCourseEnrollViewModel StudentCourseEnrollView { get; set; }

        public StudentSubmitViewModel(
            IStudentEndpoint studentEndpoint,
            ICourseEndpoint courseEndpoint)
        {
            this.studentEndpoint = studentEndpoint;
            this.courseEndpoint = courseEndpoint;

            StudentCourseEnrollView = new StudentCourseEnrollViewModel(courseEndpoint);

            StudentPhoto = @"http://web.engr.oregonstate.edu/~johnstom/img/people/placeholder.png";
        }

        public string FullName
        {
            get
            {
                return $"{FirstNameTextbox} {LastNameTextbox}";
            }
        }

        private string firstName;
        public string FirstNameTextbox
        {
            get { return firstName; }
            set
            {
                firstName = value;
                NotifyOfPropertyChange(() => FullName);
            }
        }

        private string lastName;
        public string LastNameTextbox
        {
            get { return lastName; }
            set
            {
                lastName = value;
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public DateTime StudentDOB { get; set; }

        public Gender SelectedGender { get; set; }

        public IEnumerable<Gender> Genders
        {
            get
            {
                return Enum.GetValues(typeof(Gender))
                    .Cast<Gender>();
            }
        }

        private string studentPhoto;

        public string StudentPhoto
        {
            get { return studentPhoto; }
            set
            {
                studentPhoto = value;
                NotifyOfPropertyChange(() => StudentPhoto);
            }
        }

        public void UploadPhoto()
        {
            // TODO: put restrictions on photo size or crop image

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a photo";
            openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.InitialDirectory = "C:\\Users\\61406\\Pictures\\posters"; // default value set for testing

            if (openFileDialog.ShowDialog() == true) // cleaner, more logical way of doing this?
            {
                StudentPhoto = openFileDialog.FileName;
            }

        }

        public int SelectedGrade { get; set; }

        public IEnumerable<int> Grades
        {
            get
            {
                return new List<int>()
                {
                    7, 8, 9, 10, 11, 12
                };
            }
        }

        public int StudentIdTextbox { get; set; }

        public void SubmitStudent()
        {
            // CREATE
            var student = new StudentSubmitDTO
            {
                FirstName = FirstNameTextbox,
                LastName = LastNameTextbox,
                Gender = SelectedGender,
                PhotoImgPath = StudentPhoto,
                Grade = SelectedGrade,
                BirthDate = StudentDOB,
                StudentId = StudentIdTextbox,
                Emails = EmailAddControlView.Emails.ToList(),
                PhoneNums = PhoneAddControlView.PhoneNums.ToList(),
                Addresses = AddressAddControlView.Addresses.ToList(),
                CourseEnrollments = StudentCourseEnrollView.CoursesEnrolledIn.ToList(),
            };

            // hack to remove circular references, must be reworked
            foreach (var item in student.CourseEnrollments)
            {
                item.Students.Clear();
                item.Teacher = null;
            }

            studentEndpoint.SubmitStudent(student);
        }
    }
}
