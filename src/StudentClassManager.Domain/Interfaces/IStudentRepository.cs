using StudentClassManager.Domain.Models;

namespace StudentClassManager.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();

        Task<Student> GetByIdAsync(int Id);

        Task UpdateAsync(Student student);

        Task CreateAsync(Student student);

        Task DisableStudantAsync(int id);

        Task<bool> ExistsById(int id);
    }
}
