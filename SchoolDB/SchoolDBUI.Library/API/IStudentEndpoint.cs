using SchoolDBUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolDBUI.Library.API
{
    public interface IStudentEndpoint
    {
        Task<List<Student>> GetAll();        
        Task SubmitStudent(StudentSubmitDTO student);
        Task<List<Student>> SearchStudent(string query);
    }
}