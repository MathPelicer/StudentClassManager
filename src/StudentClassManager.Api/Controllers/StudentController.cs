using Microsoft.AspNetCore.Mvc;
using StudentClassManager.Application.Services.Interfaces;
using StudentClassManager.Domain.Models;

namespace StudentClassManager.Api.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("/students")]
        public Task<List<Student>> GetAllStudentsAsync()
        {
            var result = studentService.GetAllAsync();

            return result;
        }

        [HttpPost("/student")]
        public async Task CreateStudentsAsync(Application.Dto.Student student)
        {
            await studentService.Insert(student);
        }

        [HttpPut("/student/{Id}")]
        public async Task UpdateStudentsAsync(Application.Dto.Student student, int Id)
        {
            await studentService.UpdateAsync(student, Id);
        }

        [HttpDelete("/student/{Id}")]
        public async Task DisableStudentAsync(int Id)
        {
            await studentService.DisableStudantAsync(Id);
        }
    }
}
