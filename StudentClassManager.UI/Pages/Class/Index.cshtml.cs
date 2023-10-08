using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentClassManager.UI.Clients.Interfaces;

namespace StudentClassManager.UI.Pages.Class
{
    public class IndexModel : PageModel
    {
        private readonly IClassClient classService;

        [BindProperty]
        public IList<Models.Class> classes { get; set; }

        public IndexModel(IClassClient classService)
        {
            this.classService = classService;
        }

        public async Task<IActionResult> OnGet()
        {
            classes = await classService.GetAllAsync();
            return Page();
        }
    }
}
