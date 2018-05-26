using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;

namespace RedeSocialCondominio.Repositories
{
    public class VisitanteRepository : IVisitanteRepository
    {
        private ApplicationDbContext _ctx;

        public VisitanteRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(Visitante visitante)
        {
            _ctx.Visitantes.Add(visitante);
        }

        public IEnumerable<Visitante> GetAllVisitantes()
        {
            return _ctx.Visitantes.ToList();
        }

        public IEnumerable<Visitante> GetAllVisitantesPorPeriodo(DateTime de, DateTime ate)
        {
            return _ctx.Visitantes.Where(d => d.DiaVisita >= de && d.DiaVisita <= ate).ToList();

            //var visitantesPorPeriodo = new List<Visitante>();
            //var visitantes = GetAllVisitantes();

            //foreach (var v in visitantes)
            //{
            //    if (v.DiaVisita >= de && v.DiaVisita <= ate)
            //    {

            //    }
            //}
        }

        public IEnumerable<Visitante> GetTodosVisitantesPorUsuario(string id)
        {
            return _ctx.Visitantes.Where(v => v.UsuarioId == id).ToList().OrderBy(v => v.DiaVisita);
        }
    }
}