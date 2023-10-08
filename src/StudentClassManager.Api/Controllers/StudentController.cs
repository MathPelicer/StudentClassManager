using Microsoft.AspNetCore.Mvc;
using StudentClassManager.Application.Services.Interfaces;
using StudentClassManager.Domain.Models;

namespace StudentClassManager.Api.Controllers
{
    [ApiController]
    [Route("api/Student")]
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<Student>>> GetAllStudentsAsync()
        {
            var result = await studentService.GetAllAsync();

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<ActionResult> CreateStudentsAsync([FromBody] Application.Dto.StudentDto student)
        {
            await studentService.Insert(student);

            return Ok();
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateStudentsAsync([FromBody] Application.Dto.StudentDto student, [FromRoute] int Id)
        {
            await studentService.UpdateAsync(student, Id);

            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DisableStudentAsync([FromRoute]int Id)
        {
            await studentService.DisableStudantAsync(Id);

            return Ok();
        }
    }
}
