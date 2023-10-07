using Dapper;
using StudentClassManager.Domain.Interfaces;
using StudentClassManager.Domain.Models;
using StudentClassManager.Infrastructure.Interfaces;

namespace StudentClassManager.Infrastructure.Repositories
{
    public class ClassStudentRepository : IClassStudentRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public ClassStudentRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AssociateClassStudent(int studentId, int classId)
        {
            var parameters = new
            {
                StudentId = studentId,
                ClassId = classId
            };

            var associateQuery = @"INSERT INTO aluno_turma (aluno_id, turma_id) VALUES (@StudentId, @ClassId);";

            await unitOfWork.Connection.ExecuteAsync(associateQuery, parameters);
        }

        public async Task DisassociateClassStudent(int studentId, int classId)
        {
            var parameters = new
            {
                StudentId = studentId,
                ClassId = classId
            };

            var disassociateQuery = @"DELETE FROM aluno_turma WHERE aluno_id = @StudentId AND turma_id = @ClassId";

            await unitOfWork.Connection.ExecuteAsync(disassociateQuery, parameters);
        }

        public async Task<List<Student>> GetAvailableStudentsByClass(int classId)
        {
            var parameters = new
            {
                ClassId = classId
            };

            var query = "SELECT * FROM aluno WHERE id NOT IN (SELECT aluno_id FROM aluno_turma WHERE turma_id = @ClassId)";

            var students = await unitOfWork.Connection.QueryAsync<Student>(query, parameters);

            return students.ToList();
        }

        public async Task<bool> IsStudentInClass(int studentId, int classId)
        {
            var parameters = new
            {
                StudentId = studentId,
                ClassId = classId
            };

            var query = "SELECT * FROM aluno_turma WHERE aluno_id = @StudentId AND turma_id = @ClassId";

            var result = await unitOfWork.Connection.QueryAsync<Student>(query, parameters);

            if(result == null || result.Any())
            {
                return true;
            }

            return false;
        }
    }
}
