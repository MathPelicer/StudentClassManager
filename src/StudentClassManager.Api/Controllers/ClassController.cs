using Microsoft.AspNetCore.Mvc;
using StudentClassManager.Application.Dto;
using StudentClassManager.Application.Services.Interfaces;
using StudentClassManager.Domain.Models;

namespace StudentClassManager.Api.Controllers
{
    [ApiController]
    [Route("api/Class")]
    public class ClassController : Controller
    {
        private readonly IClassService classService;

        public ClassController(IClassService classService)
        {
            this.classService = classService;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<Class>>> GetAllStudentsAsync()
        {
            var result = await classService.GetAllAsync();

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<ActionResult> CreateClassAsync([FromBody] ClassDto @class)
        {
            await classService.Insert(@class);

            return Ok();
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateClassAsync([FromBody] ClassDto @class, [FromRoute] int Id)
        {
            await classService.UpdateAsync(@class, Id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DisableStudentAsync([FromRoute] int id)
        {
            await classService.DisableClassAsync(id);

            return Ok();
        }
    }
}
