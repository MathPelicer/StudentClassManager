using StudentClassManager.UI.Clients.Interfaces;
using StudentClassManager.UI.Models;

namespace StudentClassManager.UI.Clients
{
    public class StudentClient : IStudentClient
    {
        private const string baseUrl = "api/Student";

        private readonly HttpClient _httpClient;

        public StudentClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task DisableStudantAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Student>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(baseUrl);

            var students = await response.Content.ReadFromJsonAsync<IList<Student>>();

            return students!;
        }

        public async Task Insert(Student student)
        {
            await _httpClient.PostAsJsonAsync(baseUrl, student);
        }

        public Task UpdateAsync(Student student, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
