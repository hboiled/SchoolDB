using SchoolDBUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBUI.Library.API
{
    public class TeacherEndpoint : ITeacherEndpoint
    {
        private IAPIHelper _apiHelper;

        public TeacherEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<Teacher>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/teachers"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<Teacher>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<Teacher>> GetTeachersBySubject(Subject subject)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient
                .GetAsync($"api/teachers/subjects/{subject.ToString()}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<Teacher>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
