using StudentClassManager.Domain.Models;

namespace StudentClassManager.Application.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAllAsync();

        Task UpdateAsync(Dto.StudentDto student, int Id);

        Task Insert(Dto.StudentDto student);

        Task DisableStudantAsync(int id);
    }
}
