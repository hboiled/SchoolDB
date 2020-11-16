using SchoolDBUI.Library.Models;
using SchoolDBUI.Library.Models.SubmitDTOs;
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
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<Student>> SearchStudent(string query)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/students/search/{query}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<Student>>();
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
