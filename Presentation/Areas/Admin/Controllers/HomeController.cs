using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjektiTI2.App.Constants;

namespace Presentation.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        [Authorize(Roles = RoleConstants.Admin)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
