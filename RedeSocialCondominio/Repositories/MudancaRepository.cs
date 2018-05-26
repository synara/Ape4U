using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Repositories
{
    public class MudancaRepository : IMudancaRepository
    {
        private ApplicationDbContext _ctx;

        public MudancaRepository(ApplicationDbContext ctx)
        {
            this._ctx = ctx;
        }

        public void Add(Mudanca mudanca)
        {
           _ctx.Mudancas.Add(mudanca);

        }

        public List<Mudanca> GetAllMudancas()
        {
            return _ctx.Mudancas.ToList();
        }

        public Mudanca GetMudancaPorData(DateTime data)
        {
           return _ctx.Mudancas.Where(m => m.Data == data).FirstOrDefault();
        }

        public List<Mudanca> GetMudancasPorId(string id)
        {
            return _ctx.Mudancas.Where(m => m.UsuarioId == id).ToList();
        }
    }
}