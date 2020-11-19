using Caliburn.Micro;
using SchoolDBUI.Library.API;
using SchoolDBUI.Library.Models;
using SchoolDBUI.Library.Models.SchoolBusiness;
using SchoolDBUI.Library.Models.SubmitDTOs;
using SchoolDBUI.ViewModels.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBUI.ViewModels
{
    public class StaffManagementViewModel : Screen
    {
        private readonly ITeacherEndpoint teacherEndpoint;
        private  ICourseEndpoint courseEndpoint;

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

        #region Course and subject filter

        private string selectedSubjectFilter;
        public string SelectedSubjectFilter
        {
            get { return selectedSubjectFilter; }
            set
            {
                selectedSubjectFilter = value;
                SetCourseFilter();
                NotifyOfPropertyChange(() => SelectedSubjectFilter);
            }
        }

        private async Task SetCourseFilter()
        {
            // TODO: refactor logic to be more readable 
            if (Enum.TryParse(SelectedSubjectFilter, out Subject subject))
            {
                var courses = await courseEndpoint.GetCoursesBySubject(subject);
                FilterNotSelected = courses.Count != 0;

                var filteredCourses = FilterCoursesByLevel(courses, subject);

                FilteredCourses = new BindingList<Course>(filteredCourses);
            }
            else
            {
                // handler error
            }

        }

        private List<Course> FilterCoursesByLevel(List<Course> courses, Subject subject)
        {
            var qualification = QualificationsAddControlView.Qualifications
                .Where(q => q.Subject == subject)
                .FirstOrDefault();

            return courses
                .Where(c => c.CourseLevel <= qualification.CourseLevel)
                .ToList();
        }

        private bool filterNotSelected = false;
        public bool FilterNotSelected
        {
            get
            {
                return filterNotSelected;
            }
            set
            {
                filterNotSelected = value;
                NotifyOfPropertyChange(() => FilterNotSelected);
            }
        }

        public IEnumerable<Subject> Subjects
        {
            get
            {
                return Enum.GetValues(typeof(Subject))
                    .Cast<Subject>();
            }
        }

        public BindingList<Course> filteredCourses = new BindingList<Course>();

        public BindingList<Course> FilteredCourses
        {
            get { return filteredCourses; }
            set
            {
                filteredCourses = value;
                NotifyOfPropertyChange(() => FilteredCourses);
            }
        }

        private BindingList<Course> coursesEnrolledIn = new BindingList<Course>();

        public BindingList<Course> CoursesEnrolledIn
        {
            get { return coursesEnrolledIn; }
            set { coursesEnrolledIn = value; }
        }

        private Course selectedCourse;

        public Course SelectedCourse
        {
            get { return selectedCourse; }
            set { selectedCourse = value; }
        }

        private Course enrolledCourseSelection;

        public Course EnrolledCourseSelection
        {
            get { return enrolledCourseSelection; }
            set { enrolledCourseSelection = value; }
        }

        public void EnrollInCourse()
        {
            if (SelectedCourse != null && !AlreadyEnrolledInCourse(SelectedCourse))
            {
                CoursesEnrolledIn.Add(SelectedCourse);
            }
            else
            {
                // handle error
            }
        }

        private bool AlreadyEnrolledInCourse(Course course)
        {
            return CoursesEnrolledIn.Contains(course);
        }

        public void RemoveSelectedCourse()
        {
            CoursesEnrolledIn.Remove(EnrolledCourseSelection);
        }

        #endregion    

        public void AddStaff()
        {
            var teacher = new TeacherSubmitDTO
            {
                FirstName = "faf",
                LastName = "af",
                SubjectTeachers = new List<SubjectTeachersViewModel>
                {
                    new SubjectTeachersViewModel {CourseLevel = CourseLevel.Intermediate, Subject = Subject.Biology}
                },
                CoursesTaught = new List<Course>
                {
                    new Course
                    {
                        Id = 1
                    },
                    new Course
                    {
                        Id = 2
                    }
                }                
            };

            teacherEndpoint.SubmitTeacher(teacher);
        }
    }
}
