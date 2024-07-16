using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserAccessControl.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "RequireUserRole")]
        public IActionResult UserPage()
        {
            return View();
        }

        [Authorize(Policy = "RequireAdminRole")]
        public IActionResult AdminPage()
        {
            return View();
        }

        [Authorize(Policy = "RequireEspecialUserRole")]
        public IActionResult EspecialUserPage()
        {
            return View();
        }
    }
}
