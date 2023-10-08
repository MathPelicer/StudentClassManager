using AutoMapper;
using FluentValidation;
using StudentClassManager.Application.Exceptions;
using StudentClassManager.Application.Services.Interfaces;
using StudentClassManager.Application.Validators;
using StudentClassManager.Domain.Interfaces;
using StudentClassManager.Domain.Models;

namespace StudentClassManager.Application.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository repository;
        private readonly IMapper mapper;

        public ClassService(IClassRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task DisableClassAsync(int id)
        {
            await repository.DisableClassAsync(id);
        }

        public async Task<List<Class>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();

            if(result == null || !result.Any())
            {
                throw new NotFoundException("Não foi encontrada nenhuma turma.");
            }

            return result.ToList();
        }

        public async Task Insert(Dto.ClassDto @class)
        {
            ClassValidator validator = new ClassValidator();

            await validator.ValidateAndThrowAsync(@class);

            var upsertStudent = mapper.Map<Class>(@class);

            await repository.CreateAsync(upsertStudent);
        }

        public async Task UpdateAsync(Dto.ClassDto @class, int Id)
        {
            var existingClass = await repository.GetByIdAsync(Id);

            if (existingClass == null)
            {
                throw new NotFoundException("Não foi encontrada a turma solicitada.");
            }

            ClassValidator validator = new ClassValidator();

            await validator.ValidateAndThrowAsync(@class);

            var updateClass = mapper.Map<Class>(@class);
            updateClass.Id = Id;

            await repository.UpdateAsync(updateClass);
        }
    }
}
