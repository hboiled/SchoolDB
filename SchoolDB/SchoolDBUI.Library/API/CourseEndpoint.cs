using SchoolDBUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBUI.Library.API
{
    public class CourseEndpoint : ICourseEndpoint
    {
        private IAPIHelper _apiHelper;

        public CourseEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task DeleteCourse(int id)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.DeleteAsync("api/courses/" + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<Course>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/courses"))
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

        public async Task<List<Course>> GetCoursesBySubject(Subject subject)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient
                .GetAsync($"api/courses/subjects/{subject.ToString()}")) // rework required
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

        public async Task<List<Course>> SearchCoursesByTitle(string title)
        {
            using (HttpResponseMessage response = await 
                _apiHelper.ApiClient.GetAsync($"api/courses/search/title/{title}"))
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

        public async Task SubmitCourse(CourseSubmitDTO course)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient
                .PostAsJsonAsync($"api/courses", course))
            {
                if (response.IsSuccessStatusCode)
                {
                    
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task UpdateCourse(int id, CourseSubmitDTO course)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient
                .PutAsJsonAsync($"api/courses/" + id, course))
            {
                if (response.IsSuccessStatusCode)
                {
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
