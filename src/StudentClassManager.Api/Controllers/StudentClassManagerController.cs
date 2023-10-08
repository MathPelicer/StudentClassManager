using Microsoft.AspNetCore.Mvc;
using StudentClassManager.Application.Services.Interfaces;

namespace StudentClassManager.Api.Controllers
{
    [ApiController]
    [Route("api/ClassStudent")]
    public class StudentClassManagerController : Controller
    {
        private readonly IClassStudentService classStudentService;

        public StudentClassManagerController(IClassStudentService classStudentService)
        {
            this.classStudentService = classStudentService;
        }

        [HttpPost("/associate")]
        public async Task AssociateClassStudent(int studentId, int classId)
        {
            await classStudentService.AssociateClassStudent(studentId, classId);
        }

        [HttpDelete("/disassociate")]
        public async Task DisassociateClassStudent(int studentId, int classId)
        {
            await classStudentService.DisassociateClassStudent(studentId, classId);
        }
    }
}
