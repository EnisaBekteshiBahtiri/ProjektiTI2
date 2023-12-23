using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ProjektiTI2.App.Interfaces;
using ProjektiTI2.Data.Context;
using ProjektiTI2.Data.Entities;
using ProjektiTI2.Data.Identity;

namespace ProjektiTI2.App.Implementations
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IRolesRepository _rolesRepository;
        protected readonly ProjektiTI2_Viti3Context _e_CommerceDbContext;

        private HttpContext _httpContext { get { return _contextAccessor.HttpContext; } }

        public UserService(IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager, IUserRepository userRepository, IRolesRepository rolesRepository, ProjektiTI2_Viti3Context e_CommerceDbContext)
        {
            _contextAccessor = contextAccessor;
            _userManager = userManager;
            _userRepository = userRepository;
            _rolesRepository = rolesRepository;
            if (_httpContext.User.Identity!.IsAuthenticated)
            {
                var id = userManager.GetUserId(_httpContext.User);
                CurrentUser = userRepository.GetByStringId(id);
                CurrentRole = _rolesRepository.GetByUserId(id);
            }
            _e_CommerceDbContext = e_CommerceDbContext;
        }

        private AspNetUser? CurrentUser { get; set; }
        private AspNetRole? CurrentRole { get; set; }
        public string GetUserEmail()
        {
            if (CurrentUser != null)
            {
                return CurrentUser.Email!;
            }
            else
            {
                return "";
            }
        }

        public string GetUserId()
        {
            try
            {


                if (CurrentUser != null)
                {
                    return CurrentUser.Id;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetUserName()
        {
            if (CurrentUser != null)
            {
                return CurrentUser.UserName!;
            }
            else
            {
                return "";
            }
        }

        public string? GetUserPhoneNumber()
        {
            if (CurrentUser != null)
            {
                return CurrentUser.PhoneNumber;
            }
            else
            {
                return "";
            }
        }

        public string GetUserRole()
        {
            if (CurrentRole != null)
            {
                return CurrentRole.Name!;
            }
            else
            {
                return "";
            }
        }

        public string GetFullName()
        {

            if (CurrentUser != null)
            {
                return CurrentUser.Name + " " + CurrentUser.Surname;
            }
            else
            {
                return "";
            }
        }
    }
}
