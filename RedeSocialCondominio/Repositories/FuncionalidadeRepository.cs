using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;

namespace RedeSocialCondominio.Repositories
{
    public class FuncionalidadeRepository : IFuncionalidadeRepository
    {
        private ApplicationDbContext _ctx;

        public FuncionalidadeRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Funcionalidade> GetAllFuncionalidades()
        {
            return _ctx.Funcionalidades.ToList();
        }

        public IEnumerable<Funcionalidade> GetAllFuncionalidadesPorPerfil(int perfilId)
        {
            return _ctx.Funcionalidades.Where(f => f.PerfilId == perfilId).ToList();   
        }
    }
}