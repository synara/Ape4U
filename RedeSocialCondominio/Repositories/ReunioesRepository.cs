using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;

namespace RedeSocialCondominio.Repositories
{
    public class ReunioesRepository : IReunioesRepository
    {
        private ApplicationDbContext _ctx;

        public ReunioesRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Reuniao> GetAllReunioes()
        {
            return _ctx.Reunioes.ToList();
        }

        public void Salvar(Reuniao reuniao)
        {
            _ctx.Reunioes.Add(reuniao);
        }
    }
}