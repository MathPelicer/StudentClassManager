using StudentClassManager.Domain.Models;

namespace StudentClassManager.Domain.Interfaces
{
    public interface IClassRepository
    {
        Task<List<Class>> GetAllAsync();

        Task<Class> GetByIdAsync(int Id);

        Task UpdateAsync(Class @class);

        Task CreateAsync(Class @class);

        Task DisableClassAsync(int id);

        Task<bool> ClassNameExists(string name);

        Task<bool> ClassExistsById(int id);
    }
}
