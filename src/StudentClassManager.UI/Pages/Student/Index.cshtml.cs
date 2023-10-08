using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentClassManager.UI.Clients.Interfaces;

namespace StudentClassManager.UI.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly IStudentClient _studentService;

        [BindProperty]
        public IList<Models.Student> Students { get; set; }

        public IndexModel(IStudentClient classService)
        {
            _studentService = classService;
        }

        public async Task<IActionResult> OnGet()
        {
            Students = await _studentService.GetAllAsync();
            return Page();
        }
    }
}

