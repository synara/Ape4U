using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;

namespace RedeSocialCondominio.Repositories
{
    public class NotificacaoReservaRepository : INotificacaoReservaRepository
    {
        private ApplicationDbContext _ctx;

        public NotificacaoReservaRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public void Add(NotificacaoReserva notificacaoReserva)
        {
            _ctx.NotificacaoReserva.Add(notificacaoReserva);
        }
    }
}