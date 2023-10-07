using StudentClassManager.Application.Exceptions;
using StudentClassManager.Application.Services.Interfaces;
using StudentClassManager.Domain.Interfaces;

namespace StudentClassManager.Application.Services
{
    public class ClassStudentService : IClassStudentService
    {
        private readonly IClassStudentRepository classStudentRepository;
        private readonly IClassRepository classRepository;
        private readonly IStudentRepository studentRepository;

        public ClassStudentService(IClassStudentRepository classStudentRepository,
            IClassRepository classRepository,
            IStudentRepository studentRepository)
        {
            this.classStudentRepository = classStudentRepository;
            this.classRepository = classRepository;
            this.studentRepository = studentRepository;
        }

        public async Task AssociateClassStudent(int studentId, int classId)
        {
            var isStudent = await studentRepository.ExistsById(studentId);

            if (!isStudent)
            {
                throw new NotFoundException("Não foi encontrado o aluno solicitado.");
            }

            var isClass = await classRepository.ClassExistsById(classId);

            if (!isClass)
            {
                throw new NotFoundException("Não foi encontrada a turma solicitada.");
            }

            var isStudentAssociated = await classStudentRepository.IsStudentInClass(studentId, classId);

            if (isStudentAssociated)
            {
                throw new BadRequestException("O aluno já está associado a turma.");
            }

            await classStudentRepository.AssociateClassStudent(studentId, classId);
        }

        public async Task DisassociateClassStudent(int studentId, int classId)
        {
            var isStudent = await studentRepository.ExistsById(studentId);

            if (!isStudent)
            {
                throw new NotFoundException("Não foi encontrado o aluno solicitado.");
            }

            var isClass = await classRepository.ClassExistsById(classId);

            if (!isClass)
            {
                throw new NotFoundException("Não foi encontrada a turma solicitada.");
            }

            var isStudentAssociated = await classStudentRepository.IsStudentInClass(studentId, classId);

            if (!isStudentAssociated)
            {
                throw new BadRequestException("O aluno não está associado nesta turma.");
            }

            await classStudentRepository.DisassociateClassStudent(studentId, classId);
        }
    }
}
