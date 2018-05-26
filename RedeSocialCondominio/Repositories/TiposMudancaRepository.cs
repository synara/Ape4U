using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;

namespace RedeSocialCondominio.Repositories
{
    public class TiposMudancaRepository : ITipoMudancaRepository
    {
        private ApplicationDbContext _ctx;

        public TiposMudancaRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<TipoMudanca> GetAllTiposMudanca()
        {
            return _ctx.TiposMudanca.ToList();
        }
    }
}