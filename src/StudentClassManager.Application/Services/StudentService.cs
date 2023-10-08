using AutoMapper;
using FluentValidation;
using StudentClassManager.Application.Exceptions;
using StudentClassManager.Application.Services.Interfaces;
using StudentClassManager.Application.Validators;
using StudentClassManager.Domain.Interfaces;
using StudentClassManager.Domain.Models;
using System.Text;

namespace StudentClassManager.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentService(IStudentRepository studentRepository,
            IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        public async Task DisableStudantAsync(int id)
        {
            await studentRepository.DisableStudantAsync(id);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            var result = await studentRepository.GetAllAsync();

            if (result == null || !result.Any())
            {
                throw new NotFoundException("Não foi encontrada nenhuma aluno.");
            }

            return result.ToList();
        }

        public async Task Insert(Dto.StudentDto student)
        {
            StudentValidator validator = new StudentValidator();

            await validator.ValidateAndThrowAsync(student);

            var insertStudent = mapper.Map<Student>(student);
            insertStudent.Senha = sha256(student.Senha);

            await studentRepository.CreateAsync(insertStudent);
        }

        public async Task UpdateAsync(Dto.StudentDto student, int Id)
        {
            var existingStudent = await studentRepository.GetByIdAsync(Id);

            if (existingStudent == null)
            {
                throw new NotFoundException("Não foi encontrada o aluno solicitado.");
            }

            StudentValidator validator = new StudentValidator();

            await validator.ValidateAndThrowAsync(student);

            var upsertStudent = mapper.Map<Student>(student);
            upsertStudent.Id = Id;

            await studentRepository.UpdateAsync(upsertStudent);
        }

        private static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
