using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SchoolDBUI.Library.API
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
    }
}
