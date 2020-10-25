using SchoolDBUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolDBUI.Library.API
{
    public interface ITeacherEndpoint
    {
        Task<List<Teacher>> GetAll();
        Task<List<Teacher>> GetTeachersBySubject(Subject subject);
    }
}