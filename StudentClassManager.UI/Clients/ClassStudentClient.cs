using StudentClassManager.UI.Clients.Interfaces;

namespace StudentClassManager.UI.Clients
{
    public class ClassStudentClient : IClassStudentClient
    {
        private const string baseUrl = "api/ClassStudent";

        private readonly HttpClient _httpClient;

        public ClassStudentClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


    }
}
