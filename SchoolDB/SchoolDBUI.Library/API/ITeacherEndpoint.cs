using SchoolDBUI.Library.Models;
using SchoolDBUI.Library.Models.SubmitDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolDBUI.Library.API
{
    public interface ITeacherEndpoint
    {
        Task<List<Teacher>> GetAll();
        Task<List<Teacher>> GetTeachersBySubject(Subject subject);
        Task SubmitTeacher(TeacherSubmitDTO teacher);
    }
}