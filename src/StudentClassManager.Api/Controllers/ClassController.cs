using Microsoft.AspNetCore.Mvc;
using StudentClassManager.Application.Services.Interfaces;
using StudentClassManager.Domain.Models;

namespace StudentClassManager.Api.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassService classService;

        public ClassController(IClassService classService)
        {
            this.classService = classService;
        }

        [HttpGet("/classes")]
        public Task<List<Class>> GetAllStudentsAsync()
        {
            var result = classService.GetAllAsync();

            return result;
        }

        [HttpPost("/class")]
        public async Task CreateStudentsAsync(Application.Dto.Class @class)
        {
            await classService.Insert(@class);
        }

        [HttpPut("/class/{Id}")]
        public async Task UpdateClassAsync(Application.Dto.Class @class, int Id)
        {
            await classService.UpdateAsync(@class, Id);
        }

        [HttpDelete("/class/{id}")]
        public async Task DisableStudentAsync(int id)
        {
            await classService.DisableClassAsync(id);
        }
    }
}
