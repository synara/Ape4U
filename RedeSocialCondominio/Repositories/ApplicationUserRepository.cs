using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Repositories
{
    public class ApplicationUserRepository
    {
        ApplicationDbContext _ctx;

        public ApplicationUserRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<ApplicationUser> GetAllUsers()
        {
            return _ctx.ApplicationUsers.ToList();
        }
    }
}