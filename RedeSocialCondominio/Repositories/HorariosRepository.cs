using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;
using RedeSocialCondominio.Persistence;

namespace RedeSocialCondominio.Repositories
{
    public class HorariosRepository : IHorariosRepository
    {
        ApplicationDbContext _ctx;

        public HorariosRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Adicionar(Horario horario)
        {
            _ctx.Horarios.Add(horario);
        }

        public IEnumerable<Horario> GetAllHorarios()
        {
            return _ctx.Horarios.ToList();
        }
    }
}