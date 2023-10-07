using Dapper;
using StudentClassManager.Domain.Interfaces;
using StudentClassManager.Domain.Models;
using StudentClassManager.Infrastructure.Interfaces;

namespace StudentClassManager.Infrastructure.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public ClassRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> ClassExistsById(int id)
        {
            var parameters = new { id };

            var query = "SELECT * FROM turma WHERE id = @id";

            var result = await unitOfWork.Connection.QueryAsync<Class>(query, parameters);

            if (result != null && result.Any())
            {
                return true;
            }

            return false;
        }

        public async Task<bool> ClassNameExists(string name)
        {
            var parameters = new { name };

            var query = "SELECT * FROM turma WHERE name = @name";

            var result = await unitOfWork.Connection.QueryAsync<Class>(query, parameters);

            if (result != null && result.Any())
            {
                return true;
            }

            return false;
        }

        public async Task CreateAsync(Class @class)
        {
            var parameters = new Class
            {
                CursoId = @class.CursoId,
                Turma = @class.Turma,
                Ano = @class.Ano
            };

            var insertQuery = "INSERT INTO turma (turma_id, turma, ano) VALUES (@CursoId, @Turma, @Ano);";

            await unitOfWork.Connection.ExecuteAsync(insertQuery, parameters);
        }

        public async Task DisableClassAsync(int id)
        {
            var parameters = new { id };

            var query = "DELETE FROM turma WHERE id = @id";

            await unitOfWork.Connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<Class>> GetAllAsync()
        {
            var query = "SELECT * FROM turma";

            var result = await unitOfWork.Connection.QueryAsync<Class>(query);

            return result.ToList();
        }

        public async Task<Class> GetByIdAsync(int Id)
        {
            var parameters = new
            {
                Id
            };

            var query = "SELECT * FROM turma WHERE id = @Id";

            var existingClass = await unitOfWork.Connection.QueryAsync<Class>(query, parameters);

            return existingClass.FirstOrDefault();
        }

        public async Task UpdateAsync(Class @class)
        {
            var parameters = new Class
            {
                Id = @class.Id,
                CursoId = @class.CursoId,
                Turma = @class.Turma,
                Ano = @class.Ano
            };

            var updateQuery = "UPDATE turma SET curso_id = @CursoId, turma = @Turma, ano = @Ano WHERE id = @Id";

            await unitOfWork.Connection.ExecuteAsync(updateQuery, parameters);
        }
    }
}
