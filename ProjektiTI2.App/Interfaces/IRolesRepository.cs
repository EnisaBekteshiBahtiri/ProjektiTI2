using ProjektiTI2.Data.Entities;
namespace ProjektiTI2.App.Interfaces
{
    public interface IRolesRepository : IRepository<AspNetRole>
    {
        AspNetRole? GetByUserId(string userId);
        AspNetRole? GetByStringId(string id);

    }
}
