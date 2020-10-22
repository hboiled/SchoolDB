using SchoolDBUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBUI.Library.API
{
    public class StudentEndpoint : IStudentEndpoint
    {
        private IAPIHelper _apiHelper;

        public StudentEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<Student>> GetAll()
        {            
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/students"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<Student>>();
                    var x = result.Count;
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<Course>> GetCoursesBySubject(Subject subject)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient
                .GetAsync($"api/students/courses/{subject.ToString()}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<Course>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task SubmitStudent(StudentSubmitDTO student)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient
                .PostAsJsonAsync($"api/students", student))
            {
                if (response.IsSuccessStatusCode)
                {
                    var x = "Working";                    
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
