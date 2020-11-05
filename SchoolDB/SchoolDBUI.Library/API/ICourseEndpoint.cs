﻿using SchoolDBUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolDBUI.Library.API
{
    public interface ICourseEndpoint
    {
        Task<List<Course>> GetAll();
        Task<List<Course>> SearchCoursesByTitle(string title);
        Task<List<Course>> GetCoursesBySubject(Subject subject);
        Task SubmitCourse(CourseSubmitDTO course);
    }
}