using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserAccessControl.Pages
{
    [Authorize(Roles = "User")]
    public class UserPageModel : PageModel
    {
        private readonly ILogger<UserPageModel> _logger;

        public UserPageModel(ILogger<UserPageModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("UserPage OnGet called");
            ViewData["Title"] = "User Page";
        }
    }
}
