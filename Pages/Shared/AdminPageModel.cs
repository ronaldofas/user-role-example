using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserAccessControl.Pages
{
    [Authorize(Roles = "Admin")]
    public class AdminPageModel : PageModel
    {
        private readonly ILogger<AdminPageModel> _logger;

        public AdminPageModel(ILogger<AdminPageModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("AdminPage OnGet called");
            ViewData["Title"] = "Admin Page";
        }
    }
}
