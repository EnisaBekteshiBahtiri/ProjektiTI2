﻿using Microsoft.EntityFrameworkCore;
using ProjektiTI2.App.Interfaces;
using ProjektiTI2.Data.Context;
using ProjektiTI2.Data.Entities;

namespace ProjektiTI2.App.Implementations
{
    public class RolesRepository : Repository<AspNetRole>, IRolesRepository
    {
        protected readonly ProjektiTI2_Viti3Context _e_CommerceDbContext;

        public RolesRepository(ProjektiTI2_Viti3Context e_CommerceDbContext) : base(e_CommerceDbContext)
        {
            _e_CommerceDbContext = e_CommerceDbContext;
        }

        public AspNetRole? GetByStringId(string id)
        {
            return _e_CommerceDbContext.AspNetRoles.FirstOrDefault(x => x.Id == id);
        }

        public AspNetRole? GetByUserId(string userId)
        {
            return _e_CommerceDbContext.AspNetUsers.Include(x => x.Roles).FirstOrDefault(x => x.Id == userId)?.Roles.FirstOrDefault();
        }
    }
}
