using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentClassManager.UI.Clients.Interfaces;

namespace StudentClassManager.UI.Pages.Student
{
    public class CreateStudentModel : PageModel
    {
        private readonly IStudentClient studentClient;

        [BindProperty]
        public Models.Student newStudent { get; set; }

        public CreateStudentModel(IStudentClient studentClient)
        {
            this.studentClient = studentClient;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await studentClient.Insert(newStudent);

            return RedirectToPage("Index");
        }
    }
}
