using StudentClassManager.Domain.Models;

namespace StudentClassManager.Application.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAllAsync();

        Task UpdateAsync(Dto.Student student, int Id);

        Task Insert(Dto.Student student);

        Task DisableStudantAsync(int id);
    }
}
