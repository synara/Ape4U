using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;

namespace RedeSocialCondominio.Repositories
{
    public class NotificacaoReuniaoRepository : INotificacaoReuniaoRepository
    {
        private ApplicationDbContext _ctx;

        public NotificacaoReuniaoRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public void Add(NotificacaoReuniao reuniao)
        {
            _ctx.NotificacaoReuniao.Add(reuniao);
        }

        public List<NotificacaoReserva> GetAllReunioes()
        {
            return _ctx.NotificacaoReserva.ToList();
        }

        public List<NotificacaoReserva> GetAllReunioesPorId(int id)
        {
            return _ctx.NotificacaoReserva.Where(r => r.Id == id).ToList();
        }
    }
}