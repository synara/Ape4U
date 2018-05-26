using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;

namespace RedeSocialCondominio.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        private ApplicationDbContext _ctx;

        public PerfilRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Perfil> PerfisUsuario()
        {
            return _ctx.Perfis.Where(p => p.Id == 2 || p.Id == 3).ToList();
        }
    }
}