using StudentClassManager.UI.Clients.Interfaces;
using StudentClassManager.UI.Models;

namespace StudentClassManager.UI.Clients
{
    public class ClassClient : IClassClient
    {
        private const string baseUrl = "api/Class";

        private readonly HttpClient _httpClient;

        public ClassClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task DisableClassAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Class>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(baseUrl);

            var classes =  await response.Content.ReadFromJsonAsync<IList<Class>>();

            return classes!;
        }

        public async Task Insert(Class @class)
        {
            await _httpClient.PostAsJsonAsync(baseUrl, @class);
        }

        public Task UpdateAsync(Class @class, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
