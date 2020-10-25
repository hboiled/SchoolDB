﻿using SchoolDBUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolDBUI.Library.API
{
    public interface ICourseEndpoint
    {
        Task<List<Course>> GetAll();
    }
}