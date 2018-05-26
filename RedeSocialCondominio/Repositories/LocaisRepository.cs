using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;

namespace RedeSocialCondominio.Repositories
{
    public class LocaisRepository : ILocaisRepository
    {
        ApplicationDbContext _ctx = new ApplicationDbContext();

        public LocaisRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Local> GetAllLocais()
        {
            return _ctx.Locais.ToList();
        }

        public Local GetLocalPorId(int id)
        {
            return _ctx.Locais.Where(l => l.Id == id).FirstOrDefault();
        }
    }
}