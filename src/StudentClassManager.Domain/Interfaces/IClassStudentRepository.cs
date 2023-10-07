using StudentClassManager.Domain.Models;

namespace StudentClassManager.Domain.Interfaces
{
    public interface IClassStudentRepository
    {
        public Task DisassociateClassStudent(int studentId, int classId);

        public Task AssociateClassStudent(int studentId, int classId);

        public Task<List<Student>> GetAvailableStudentsByClass(int classId);

        public Task<bool> IsStudentInClass(int studentId, int classId);
    }
}
