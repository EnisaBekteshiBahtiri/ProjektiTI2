using ProjektiTI2.Data.Entities;

namespace ProjektiTI2.App.Interfaces
{
    public interface IUserRepository : IRepository<AspNetUser>
    {
        AspNetUser? GetByStringId(string id);
        List<AspNetUser> GetAllWithRoles();


    }
}
