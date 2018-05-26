using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;
using System.Data.Entity;

namespace RedeSocialCondominio.Repositories
{
    public class ReservaRepository : IReservasRepository
    {
        ApplicationDbContext _ctx;

        public ReservaRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Adicionar(Reserva reserva)
        {
            _ctx.Reservas.Add(reserva);
        }

        public void Deletar(int id)
        {
            var reserva = GetReservaPorId(id);

            if (reserva != null) _ctx.Reservas.Remove(reserva);
        }

        public List<Reserva> GetReservasPorHoraLocal(DateTime dia, int id)
        {
            return _ctx.Reservas
                        .Where(r => DbFunctions.TruncateTime(r.HoraInicio) == dia.Date && r.LocalId == id).OrderBy(r => r.HoraInicio).ToList();
        }

        public Reserva GetReservaPorId(int id)
        {
            return _ctx.Reservas.Where(r => r.Id == id).FirstOrDefault();
        }

        public IEnumerable<Reserva> GetReservas()
        {
            return _ctx.Reservas.ToList();
        }
    }
}