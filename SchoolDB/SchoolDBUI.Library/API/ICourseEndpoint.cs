﻿using SchoolDBUI.Library.Models;
using SchoolDBUI.Library.Models.SubmitDTOs;
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
        Task UpdateCourse(int id, CourseSubmitDTO course);
        Task DeleteCourse(int id);
    }
}