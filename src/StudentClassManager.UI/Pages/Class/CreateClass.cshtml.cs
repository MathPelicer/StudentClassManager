using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentClassManager.UI.Clients.Interfaces;

namespace StudentClassManager.UI.Pages.Class
{
    public class CreateClassModel : PageModel
    {
        private readonly IClassClient classClient;

        [BindProperty]
        public Models.Class newClass { get; set; }

        public CreateClassModel(IClassClient classClient)
        {
            this.classClient = classClient;
        }

        public async void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost()
        {
            await classClient.Insert(newClass);

            return RedirectToPage("Index");
        }
    }
}
