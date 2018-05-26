using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;

namespace RedeSocialCondominio.Repositories
{
    public class EncomendasRepository : IEncomendasRepository
    {
        private ApplicationDbContext _ctx;

        public EncomendasRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Complete(Encomenda encomenda)
        {
            _ctx.Encomendas.Add(encomenda);
        }

        public IEnumerable<Encomenda> GetAllEncomendas()
        {
            return _ctx.Encomendas.ToList();
        }

        public Encomenda GetEncomendaPorId(int id)
        {
            return _ctx.Encomendas.Where(e => e.Id == id).FirstOrDefault();
        }

        public IEnumerable<Encomenda> GetEncomendasPorPeriodo(DateTime de, DateTime ate)
        {
            return _ctx.Encomendas.Where(e => e.DataHoraEntrega >= de && e.DataHoraEntrega <= ate).ToList();
        }
    }
}