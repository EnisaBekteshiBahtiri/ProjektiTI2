using Microsoft.AspNetCore.Mvc;
using ProjektiTI2.App.Constants;
using ProjektiTI2.App.Interfaces;

namespace Presentation.Areas.Admin.Controllers
{
    [Area(AreasConstants.Admin)]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetUsersJson()
        {
            try
            {
                var users = userRepository.GetAll();

                var result = users.Select(x => new
                {
                    //id = x.Id,
                    name = x.Name,
                    surname = x.Surname,
                    email = x.Email,
                    emailConfirmed = x.EmailConfirmed,
                }).ToList();

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
