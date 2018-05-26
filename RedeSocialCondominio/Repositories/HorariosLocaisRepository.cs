using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;

namespace RedeSocialCondominio.Repositories
{
    public class HorariosLocaisRepository : IHorariosLocaisRepository
    {
        private ApplicationDbContext _ctx;

        public HorariosLocaisRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<HorariosLocais> GetHorariosPorId(int id)
        {
            return _ctx.HorariosLocais.Where(h => h.LocalId == id)
                        .OrderBy(h => h.HorarioInicial).ToList();
        }
    }
}