using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserAccessControl.Pages.Shared
{
    [Authorize(Roles = "EspecialUser")]
    public class EspecialUserPageModel : PageModel
    {
        private readonly ILogger<EspecialUserPageModel> _logger;

        public EspecialUserPageModel(ILogger<EspecialUserPageModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("EspecialUserPage OnGet called");
            ViewData["Title"] = "Especial User Page";
        }
    }
}
