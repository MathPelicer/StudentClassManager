using StudentClassManager.Application.Dto;

namespace StudentClassManager.Application.Services.Interfaces
{
    public interface IClassService
    {
        Task<List<Domain.Models.Class>> GetAllAsync();

        Task UpdateAsync(ClassDto @class, int Id);

        Task Insert(ClassDto @class);

        Task DisableClassAsync(int id);
    }
}
