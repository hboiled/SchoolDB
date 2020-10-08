using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace SchoolDBUI.Library.API
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient _apiClient;

        public HttpClient ApiClient
        {
            get
            {
                return _apiClient;
            }
        }

        public APIHelper()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {
            string api = "https://localhost:5001/";

            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(api);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(
                // set to retrieve json
                new MediaTypeWithQualityHeaderValue("application/json")
                );
        }
    }
}
