using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialCondominio.Repositories
{
    public interface IReservasRepository
    {
        void Adicionar(Reserva reserva);
        IEnumerable<Reserva> GetReservas();
        Reserva GetReservaPorId(int id);
        void Deletar(int id);
        List<Reserva> GetReservasPorHoraLocal(DateTime dia, int id);
    }
}
