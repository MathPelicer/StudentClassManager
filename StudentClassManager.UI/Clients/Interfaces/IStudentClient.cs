using StudentClassManager.UI.Models;

namespace StudentClassManager.UI.Clients.Interfaces
{
    public interface IStudentClient
    {
        public Task<IList<Student>> GetAllAsync();

        Task UpdateAsync(Student student, int Id);

        Task Insert(Student student);

        Task DisableStudantAsync(int id);
    }
}
