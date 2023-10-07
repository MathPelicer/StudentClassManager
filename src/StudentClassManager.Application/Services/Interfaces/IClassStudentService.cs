namespace StudentClassManager.Application.Services.Interfaces
{
    public interface IClassStudentService
    {
        Task AssociateClassStudent(int studentId, int classId);

        Task DisassociateClassStudent(int studentId, int classId);
    }
}
