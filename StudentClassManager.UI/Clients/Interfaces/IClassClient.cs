using StudentClassManager.UI.Models;

namespace StudentClassManager.UI.Clients.Interfaces
{
    public interface IClassClient
    {
        Task<IList<Class>> GetAllAsync();

        Task UpdateAsync(Class @class, int Id);

        Task Insert(Class @class);

        Task DisableClassAsync(int id);
    }
}
