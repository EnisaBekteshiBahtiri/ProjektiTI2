using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Client.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
