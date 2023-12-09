using Microsoft.EntityFrameworkCore;
using ProjektiTI2.App.Interfaces;
using ProjektiTI2.Data.Context;
using ProjektiTI2.Data.Entities;

namespace ProjektiTI2.App.Implementations
{
    public class UserRepository : Repository<AspNetUser>, IUserRepository
    {
        protected readonly ProjektiTI2_Viti3Context _e_CommerceDbContext;
        public UserRepository(ProjektiTI2_Viti3Context e_CommerceDbContext) : base(e_CommerceDbContext)
        {
            _e_CommerceDbContext = e_CommerceDbContext;
        }

        public AspNetUser? GetByStringId(string id)
        {
            return _e_CommerceDbContext.AspNetUsers.FirstOrDefault(x => x.Id == id);
        }

        public List<AspNetUser> GetAllWithRoles()
        {
            return _e_CommerceDbContext.AspNetUsers.Include(x => x.Roles).ToList();
        }
    }
}
