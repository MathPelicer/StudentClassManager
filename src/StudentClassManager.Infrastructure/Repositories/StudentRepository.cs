using Dapper;
using StudentClassManager.Domain.Interfaces;
using StudentClassManager.Domain.Models;
using StudentClassManager.Infrastructure.Interfaces;

namespace StudentClassManager.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public StudentRepository(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Student student)
        {
            var parameters = new Student
            {
                Nome = student.Nome,
                Usuario = student.Usuario,
                Senha = student.Senha
            };

            var insertQuery = @"INSERT INTO aluno (nome, usuario, senha) VALUES (@Nome, @Usuario, @Senha);";

            await unitOfWork.Connection.ExecuteAsync(insertQuery, parameters);
        }

        public async Task DisableStudantAsync(int id)
        {
            var parameters = new { id };

            var query = "DELETE FROM aluno WHERE id = @id";

            await unitOfWork.Connection.ExecuteAsync(query, parameters);
        }

        public async Task<bool> ExistsById(int id)
        {
            var parameters = new
            {
                id
            };

            var query = "SELECT * FROM aluno WHERE id = @id";

            var existingStudent = await unitOfWork.Connection.QueryAsync<Student>(query, parameters);

            if(existingStudent != null && existingStudent.Any())
            {
                return true;
            }

            return false;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            var query = "SELECT * FROM aluno";

            var result = await unitOfWork.Connection.QueryAsync<Student>(query);

            return result.ToList();
        }

        public async Task<Student> GetByIdAsync(int Id)
        {
            var parameters = new
            {
                Id
            };

            var query = "SELECT * FROM aluno WHERE id = @Id";            

            var existingStudent = await unitOfWork.Connection.QueryAsync<Student>(query, parameters);

            return existingStudent.FirstOrDefault();
        }

        public async Task UpdateAsync(Student student)
        {
            var parameters = new Student
            {
                Id = student.Id,
                Nome = student.Nome,
                Usuario = student.Usuario,
                Senha = student.Senha
            };

            var updateQuery = "UPDATE aluno SET nome = @Nome, usuario = @Usuario, senha = @Senha WHERE id = @Id";

            await unitOfWork.Connection.ExecuteAsync(updateQuery, parameters);
            
        }
    }
}
