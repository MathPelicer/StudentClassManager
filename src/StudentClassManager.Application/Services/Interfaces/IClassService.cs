using StudentClassManager.Domain.Models;

namespace StudentClassManager.Application.Services.Interfaces
{
    public interface IClassService
    {
        Task<List<Class>> GetAllAsync();

        Task UpdateAsync(Dto.Class @class, int Id);

        Task Insert(Dto.Class @class);

        Task DisableClassAsync(int id);
    }
}
